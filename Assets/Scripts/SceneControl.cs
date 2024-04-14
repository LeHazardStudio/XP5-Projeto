using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    public UIController UIController;
    public DataHandler data;

    public TMP_Text texto_caso;
    public TMP_Text questaoA;
    public TMP_Text questaoB;

    public TMP_Text confirmacaoResposta;

    public string resposta1 = "";


    private void Start() //Desativa a questao B e posteriormente vai desativar todas alem da A quando o jogo começa
    {
        questaoB.gameObject.SetActive(false);
    }
    public void SetQuestion(int x) //Seta o texto de tudo da tela do computador, conforme o sheets
    {
        texto_caso.text = data.rawdata[x][0];
        questaoA.text = "a)" + " " + data.rawdata[x][1];
        questaoB.text = "b)" + " " + data.rawdata[x][2];
    }

    public void confirmarResposta() //Quando o candidato clica no botao de terminar questao, ele ativa a tela de confirmaçao de resposta
    {
        UIController.telaDeConfirmação();
        confirmacaoResposta.text = "Sua resposta atual é: " + resposta1 + ". " + "Deseja confirmar sua resposta?";
    }

    public void fecharQuestão() //Quando o candidato confirma resposta, a questao que ele estava é riscada e a proxima aparece 
    {
        questaoA.fontStyle = FontStyles.Strikethrough;
        questaoB.gameObject.SetActive(true);
        //Tem que fazer algo para ele salvar a resposta atual e saber que agora a resposta é para a proxima questao, para deixar todas salvas para comparar com o gabarito no final
    }
        
        
            
        
    
}
    
   
