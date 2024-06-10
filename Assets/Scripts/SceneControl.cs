using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public UIController UIController;
    public DataHandler data;
    public GameObject BarraScore;
    public Image SetaAvancar;
    public Image SetaVoltar;
    public ProgessBar progressBar;

    [Header("SPRITES DAS SETAS")]
    public Sprite avancar1;
    public Sprite avancar2;
    public Sprite voltar1;
    public Sprite voltar2;
    

    [Header("LOGIN")] 
    public TMP_InputField email;
    public TMP_InputField nome;

    [Header("QUESTAO")]
    public TMP_Text texto_caso;
    public TMP_Text questao;
    public TMP_Text numQuestao;

    [Header("SCORE")]
    public TMP_Text score;
    public TMP_Text respostas;
    
    
    [Header("RESPOSTAS ARTIGO - RESP UNITARIA")]
    public TMP_Dropdown incArt;
    public TMP_Dropdown codArt;
    public TMP_InputField art;
    public TMP_InputField paragArt;
    public TMP_InputField fundArt;
    
    [Header("RESPOSTA SUMULA - RESP UNITARIA")]
    public TMP_Dropdown incSum;
    public TMP_Dropdown codSum;
    public TMP_InputField sum;
    public TMP_InputField paragSum;
    public TMP_InputField fundSum;

    [Header("PETICAO ORDINARIA")]
    public TMP_Dropdown comarcaPetOrd;
    public TMP_Dropdown competenciaPetOrd;
    public TMP_InputField fundPetOrd;

    [Header("RESPOSTAS ARTIGO - PET ORDINARIA")]
    public TMP_Dropdown incArtPetOrd;
    public TMP_Dropdown codArtPetOrd;
    public TMP_InputField artPetOrd;
    public TMP_InputField paragArtPetOrd;
    public TMP_InputField fundArtPetOrd;


    [Header("RESPOSTA SUMULA - PET ORDINARIA")]
    public TMP_Dropdown incSumPetOrd;
    public TMP_Dropdown codSumPetOrd;
    public TMP_InputField sumPetOrd;
    public TMP_InputField paragSumPetOrd;
    public TMP_InputField fundSumPetOrd;


    [Header("PETICAO ESPECIAL")]
    public TMP_Dropdown comarcaPetEsp;
    public TMP_Dropdown competenciaPetEsp;
    public TMP_Dropdown procedimentoPetEsp;
    public TMP_InputField fundPetEsp;

    [Header("RESPOSTAS ARTIGO - PET ESPECIAL")]
    public TMP_Dropdown incArtPetEsp;
    public TMP_Dropdown codArtPetEsp;
    public TMP_InputField artPetEsp;
    public TMP_InputField paragArtPetEsp;
    public TMP_InputField fundArtPetEsp;


    [Header("RESPOSTA SUMULA - PET ESPECIAL")]
    public TMP_Dropdown incSumPetEsp;
    public TMP_Dropdown codSumPetEsp;
    public TMP_InputField sumPetEsp;
    public TMP_InputField paragSumPetEsp;
    public TMP_InputField fundSumPetEsp;



    [Header("OUTROS")]
    public TMP_Text confirmacaoResposta;
    public List<string> resposta = new List<string>();
    private List<string> fundPeticao = new List<string>();

    private int contadorResposta = 0;
    private int questionNumber = 0;
    private float numberOfFrames;
    private int currentFrame;
    private int animCuts;

    private bool petOrd;

    private bool petArt;

   

    public void SetQuestion(int x) //Seta o texto de tudo da tela do computador, conforme o sheets
    {
        
        numQuestao.text = "Questão " + (x + 1) + " - " + (contadorResposta + 1);
        texto_caso.text = data.rawdata[x][0];
        questao.text = "- " + data.rawdata[x][contadorResposta + 1];

        respostas.text = "" + (resposta.Count - 2);
    }

    public void NextQuestion()
    {
        
        if(contadorResposta == data.rawdata[questionNumber].Length - 2 && questionNumber != data.rawdata.Count - 1)
        {
            questionNumber++;
            contadorResposta = -1;
        }
        if (contadorResposta  < data.rawdata[questionNumber].Length - 2)
        {
            print(data.rawdata[questionNumber].Length);
            contadorResposta++;
            SetQuestion(questionNumber);
        }
        if (contadorResposta + 1 <= data.rawdata[questionNumber].Length - 2 || questionNumber + 1 < data.rawdata.Count)
        {
            SetaAvancar.sprite = avancar1;
        }
        else
        {
            SetaAvancar.sprite = avancar2;
        }
        if (contadorResposta - 1 >= 0 || questionNumber - 1 > -1)
        {
            SetaVoltar.sprite = voltar1;
        }
        else
        {
            SetaVoltar.sprite = voltar2;
        }

        

    }

    public void PreviousQuestion()
    {
     
        if (contadorResposta - 1 > -1)
        {
            contadorResposta--;
            SetQuestion(questionNumber);
        }
        else if(contadorResposta - 1 == -1 && questionNumber != 0)
        {
            questionNumber--;
            contadorResposta = data.rawdata[questionNumber].Length - 2;
            print("resp " + contadorResposta);
            SetQuestion(questionNumber);
        }
        if (contadorResposta - 1 >= 0 || questionNumber - 1  > -1)
        {
            SetaVoltar.sprite = voltar1;
        }
        else
        {
            SetaVoltar.sprite = voltar2;
        }
        if (contadorResposta + 1 <= data.rawdata[questionNumber].Length - 2 || questionNumber + 1 < data.rawdata.Count)
        {
            SetaAvancar.sprite = avancar1;
        }
        else
        {
            SetaAvancar.sprite = avancar2;
        }
        

    }




    /*public void confirmarResposta() //Quando o candidato clica no botao de terminar questao, ele ativa a tela de confirmaçao de resposta
    {
        UIController.telaDeConfirmação();
        confirmacaoResposta.text = "Sua resposta atual é: " + resposta + ". " + "Deseja confirmar sua resposta?";
    }*/

    public void Resposta(int x)
    {
        switch (x)
        {
            case 0: //unitaria e artigo
                resposta.Add((questionNumber + 1) + " - " + (contadorResposta + 1) + " : " + art.text + " " + paragArt.text + " " + incArt.options[incArt.value].text + " " + codArt.options[codArt.value].text +"\n"+fundArt.text);
                SetQuestion(questionNumber);
                ChecarResposta(x, questionNumber, contadorResposta);
                UIController.telaRespArt.SetActive(false);
                UIController.piscarTela.SetActive(true);
                break;
            case 1: //unitaria e sumula
                resposta.Add((questionNumber + 1) + " - " + (contadorResposta + 1) + " : " + sum.text + " " + paragSum.text + " " + incSum.options[incSum.value].text + " " + codSum.options[codSum.value].text +"\n"+fundSum.text);
                SetQuestion(questionNumber);
                ChecarResposta(x, questionNumber, contadorResposta);
                UIController.telaRespSumula.SetActive(false);
                UIController.piscarTela.SetActive(true);
                break;
            case 2: //peticao ordinaria
            
                    resposta.Add((questionNumber + 1) + " - " + (contadorResposta + 1) + " : " + comarcaPetOrd.options[comarcaPetOrd.value].text + " " + competenciaPetOrd.options[competenciaPetOrd.value].text + "\n" + fundPetOrd.text);
                    for(int i = 0; i < fundPeticao.Count; i++)
                    {
                    resposta[2 + contadorResposta] = "\n" + resposta[2 + contadorResposta] + " " + "Fundamentação" + " " + (i + 1) + " : " + fundPeticao[i];
        }
                    ChecarResposta(x, questionNumber, contadorResposta);
                    UIController.piscarTela.SetActive(true);
                    break;
            case 3: //peticao especial
                
                    resposta.Add((questionNumber + 1) + " - " + (contadorResposta + 1) + " : " + comarcaPetEsp.options[comarcaPetEsp.value].text + " " + competenciaPetEsp.options[competenciaPetEsp.value].text + " " + procedimentoPetEsp.options[competenciaPetEsp.value].text + "\n " + fundPetEsp.text);
                    for(int i = 0; i < fundPeticao.Count; i++)
                    {
                    resposta[2 + contadorResposta] = resposta[2 + contadorResposta] + " " + "Fundamentação" + " " + i + " " + fundPeticao[i];
                    }
                    ChecarResposta(x, questionNumber, contadorResposta);
                    UIController.piscarTela.SetActive(true);
                    break;
        }
        EnviarResposta();
        
        
    }

    public void ConstruirPeticaoPorArtigo()
    {
        fundPeticao.Add(artPetOrd.text + " " + paragArtPetOrd.text + " " + incArtPetOrd.options[incArtPetOrd.value].text + " " + codArtPetOrd.options[codArtPetOrd.value].text + "\n" + fundArtPetOrd.text);
        UIController.telaRespArtPEspecial.SetActive(false);
        UIController.telaPeticao.SetActive(true);
        resetFund();
    }

    public void ConstruirPeticaoPorSumula()
    {
        fundPeticao.Add(sumPetOrd.text + " " + paragSumPetOrd.text + " " + incSumPetOrd.options[incSumPetOrd.value].text + " " + codSumPetOrd.options[codSumPetOrd.value].text + "\n" + fundSumPetOrd.text);
        UIController.telaRespSumulaPEspecial.SetActive(false);
        UIController.telaPeticao.SetActive(true);
        resetFund();
    }


    public void ChecarResposta(int x, int question , int resposta)
    {
        switch (x)
        {
            case 0: //se for unitária e de artigo
                /*if (art.text + " " + paragArt.text + " " + incArt.options[incArt.value].text + " " + codArt.options[codArt.value].text == data.gabarito[0][y])
                {
                    IncreaseBar();
                }
                else
                {
                    DecreaseBar();
                }*/
                if (data.gabarito[question][resposta].Contains(art.text) && art.text != "") 
                {
                    //IncreaseBar();
                    print("art");
                    
                }
                if (data.gabarito[question][resposta].Contains(paragArt.text) && paragArt.text != "")
                {
                   // IncreaseBar();
                    print("parag");
                    print(paragArt.text);
                }
                if (data.gabarito[question][resposta].Contains(incArt.options[incArt.value].text) && incArt.options[incArt.value].text != "")
                {
                    //IncreaseBar();
                    print("inc");
                }
                if (data.gabarito[question][resposta].Contains(codArt.options[codArt.value].text) && codArt.options[codArt.value].text != "")
                {
                    //IncreaseBar();
                    print("cod");
                }
                break;
            case 1: //se for unitária e de sumula
                /*if (sum.text + " " + paragSum.text + " " + incSum.options[incSum.value].text + " " + codSum.options[codSum.value].text == data.gabarito[0][y])
                {
                    IncreaseBar();
                }
                else
                {
                    DecreaseBar();
                }*/
                if (data.gabarito[question][resposta].Contains(sum.text))
                {
                   // IncreaseBar();
                }
                if (data.gabarito[question][resposta].Contains(paragSum.text))
                {
                    //IncreaseBar();
                }
                if (data.gabarito[question][resposta].Contains(incSum.options[incSum.value].text))
                {
                    //IncreaseBar();
                }
                if (data.gabarito[question][resposta].Contains(codSum.options[codSum.value].text))
                {
                    //IncreaseBar();
                }
                break;
            case 2: //Se for petição ordinária e de artigo
               
                if (data.gabarito[question][resposta].Contains(art.text) && art.text != "")
                {
                    //IncreaseBar();
                    print("art");

                }
                if (data.gabarito[question][resposta].Contains(paragArt.text) && paragArt.text != "")
                {
                    //IncreaseBar();
                    print("parag");
                    print(paragArt.text);
                }
                if (data.gabarito[question][resposta].Contains(incArt.options[incArt.value].text) && incArt.options[incArt.value].text != "")
                {
                    //IncreaseBar();
                    print("inc");
                }
                if (data.gabarito[question][resposta].Contains(codArt.options[codArt.value].text) && codArt.options[codArt.value].text != "")
                {
                    //IncreaseBar();
                    print("cod");
                }
                break;
        }
    }

    /*public void IncreaseBar()
    {
        BarraScore.GetComponent<ProgessBar>().current += 25;
        
       
    }

    public void DecreaseBar()
    {
        BarraScore.GetComponent<ProgessBar>().current -= 25;
        

    }*/
    public void Login()
    {
        resposta.Add(nome.text);
        resposta.Add(email.text);
    }

    public void EnviarResposta()
    {
        print(resposta[contadorResposta + 2]);
        data.PegarResposta(resposta);
        resetInserts();
        //progressBar.GetComponent<Animator>().SetBool("pause", false);
        progressBar.GetComponent<Animator>().SetFloat("speed", 1);
    }

    public void resetFund()
    {
        
     incArtPetOrd.value = 0;
     codArtPetOrd.value = 0;
     artPetOrd.text = "";
     paragArtPetOrd.text = "";
     fundArtPetOrd.text = "";
     incSumPetOrd.value = 0;
     codSumPetOrd.value = 0 ;
     sumPetOrd.text = "";
     paragSumPetOrd.text = "";
     fundSumPetOrd.text = "";
    }

    public void resetInserts()
    {
        
     incArt.value = 0;
     codArt.value = 0;
     art.text = "";
     paragArt.text = "";
     fundArt.text = "";


     incSum.value = 0;
     codSum.value = 0;
     sum.text = "";
     paragSum.text = "";
     fundSum.text = "";


     comarcaPetOrd.value = 0;
     competenciaPetOrd.value = 0;
     fundPetOrd.text = "";


     comarcaPetEsp.value = 0;
     competenciaPetEsp.value = 0;
     procedimentoPetEsp.value = 0;
     fundPetEsp.text = "";

     resetFund();
    }
    
    /*public void SetScore()
    {
        score.text = score.text + " " + BarraScore.GetComponent<ProgessBar>().current + "/" + BarraScore.GetComponent<ProgessBar>().maximum;
    }*/


   
}
    
   
