using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    public UIController UIController;
    public DataHandler data;

    [Header("LOGIN")] 
    public TMP_InputField email;
    public TMP_InputField nome;

    [Header("QUESTAO")]
    public TMP_Text texto_caso;
    public TMP_Text questao;
    
    
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


    public void SetQuestion(int x) //Seta o texto de tudo da tela do computador, conforme o sheets
    {
        texto_caso.text = data.rawdata[x][0];
        questao.text = data.rawdata[x][1];
        
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
                SetQuestion(contadorResposta);
                UIController.telaRespArt.SetActive(false);
                UIController.telaComputador.SetActive(true);
                break;
            case 1:
                resposta.Add(sum.text + " " + paragSum.text + " " + incSum.options[incSum.value].text + " " + codSum.options[codSum.value].text +"\n"+fundSum.text);
                SetQuestion(contadorResposta);
                UIController.telaRespSumula.SetActive(false);
                UIController.telaComputador.SetActive(true);
                break;
        }
        
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
}
    
   
