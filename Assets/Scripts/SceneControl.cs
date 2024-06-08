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
    
    
    [Header("RESPOSTAS ARTIGO")]
    public TMP_Dropdown incArt;
    public TMP_Dropdown codArt;
    public TMP_InputField art;
    public TMP_InputField paragArt;
    public TMP_InputField fundArt;
    
    [Header("RESPOSTA SUMULA")]
    public TMP_Dropdown incSum;
    public TMP_Dropdown codSum;
    public TMP_InputField sum;
    public TMP_InputField paragSum;
    public TMP_InputField fundSum;
    public TMP_Text confirmacaoResposta;
    private List<string> resposta = new List<string>();

    private int contadorResposta = 0;
    private int questionNumber = 0;

   

    public void SetQuestion(int x) //Seta o texto de tudo da tela do computador, conforme o sheets
    {
        
        numQuestao.text = "Questão " + (x + 1) + " - " + (contadorResposta + 1);
        texto_caso.text = data.rawdata[x][0];
        questao.text = "- " + data.rawdata[x][contadorResposta + 1];


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
            case 0:
                resposta.Add(art.text + " " + paragArt.text + " " + incArt.options[incArt.value].text + " " + codArt.options[codArt.value].text +"\n"+fundArt.text);
                SetQuestion(questionNumber);
                ChecarResposta(x, contadorResposta);
                UIController.telaRespArt.SetActive(false);
                UIController.piscarTela.SetActive(true);
                break;
            case 1:
                resposta.Add(sum.text + " " + paragSum.text + " " + incSum.options[incSum.value].text + " " + codSum.options[codSum.value].text +"\n"+fundSum.text);
                SetQuestion(questionNumber);
                ChecarResposta(x, contadorResposta);
                UIController.telaRespSumula.SetActive(false);
                UIController.piscarTela.SetActive(true);
                break;
        }
        
    }

    
    public void ChecarResposta(int x, int y)
    {
        print(data.gabarito[0][y]);
        switch (x)
        {
            case 0:
                /*if (art.text + " " + paragArt.text + " " + incArt.options[incArt.value].text + " " + codArt.options[codArt.value].text == data.gabarito[0][y])
                {
                    IncreaseBar();
                }
                else
                {
                    DecreaseBar();
                }*/
                if (data.gabarito[0][y].Contains(art.text) && art.text != "") 
                {
                    IncreaseBar();
                    print("art");
                    
                }
                if (data.gabarito[0][y].Contains(paragArt.text) && paragArt.text != "")
                {
                    IncreaseBar();
                    print("parag");
                    print(paragArt.text);
                }
                //TA COM UM BUG NA VERIFICACAO DO INCISO, POIS COMO A RESPOSTA É VII, SE TIVER QUALQUER UM DOS VALORES QUE COMPOEM O VII COMO RESPOSTA, SEJA I, II, V, ETC. ELE VAI CONTAR COMO CERTO POIS TECNICAMENTE AINDA FAZ DA PARTE DA STRING
                if (data.gabarito[0][y].Contains(incArt.options[incArt.value].text) && incArt.options[incArt.value].text != "")
                {
                    IncreaseBar();
                    print("inc");
                }
                if (data.gabarito[0][y].Contains(codArt.options[codArt.value].text) && codArt.options[codArt.value].text != "")
                {
                    IncreaseBar();
                    print("cod");
                }
                break;
            case 1:
                /*if (sum.text + " " + paragSum.text + " " + incSum.options[incSum.value].text + " " + codSum.options[codSum.value].text == data.gabarito[0][y])
                {
                    IncreaseBar();
                }
                else
                {
                    DecreaseBar();
                }*/
                if (data.gabarito[0][y].Contains(sum.text))
                {
                    IncreaseBar();
                }
                if (data.gabarito[0][y].Contains(paragSum.text))
                {
                    IncreaseBar();
                }
                if (data.gabarito[0][y].Contains(incSum.options[incSum.value].text))
                {
                    IncreaseBar();
                }
                if (data.gabarito[0][y].Contains(codSum.options[codSum.value].text))
                {
                    IncreaseBar();
                }
                break;
        }
    }

    public void IncreaseBar()
    {
        BarraScore.GetComponent<ProgessBar>().current += 25;
        
       
    }

    public void DecreaseBar()
    {
        BarraScore.GetComponent<ProgessBar>().current -= 25;
        

    }
    public void Login()
    {
        resposta.Add(nome.text);
        resposta.Add(email.text);
    }

    public void EnviarResposta()
    {
        data.PegarResposta(resposta);
    }

    public void SetScore()
    {
        score.text = score.text + " " + BarraScore.GetComponent<ProgessBar>().current + "/" + BarraScore.GetComponent<ProgessBar>().maximum;
    }
}
    
   
