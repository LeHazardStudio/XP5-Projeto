using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    public SceneControl SC;
    public TMP_InputField input;
    public TMP_Dropdown dropdown;

    public string fundamentacao;
    public string artigo;
    // Start is called before the first frame update
   

    public void inserirArtigo(string art) //Insere o artigo digitado numa variavel 
    {
        artigo = art;
    }

    public void inserirFundamentacao(string fund) //Insere a fundamentacao digitada numa variavel
    {
        fundamentacao = fund;
    }


    public void FinalizarResposta() //Transforma tudo que foi digitado pelo candidato na resposta oficial da questao e manda para o SceneControl
    {
        SC.resposta1 = artigo +  "," + fundamentacao;
    }
}
