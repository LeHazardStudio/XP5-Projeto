using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public DataHandler data;

    public TMP_Text texto_caso;
    public TMP_Text questaoA;
    public TMP_Text questaoB;

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

    private void Update()
    {
        
        if(resposta1 != "") //Verifica se a resposta oficial da questao foi atualizada e se sim risca a questao a e ativa a questao b
        {
            questaoA.fontStyle = FontStyles.Strikethrough;
            questaoB.gameObject.SetActive(true);
        }
    }
}
    
   
