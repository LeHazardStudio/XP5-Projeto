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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Senha(string senha)
    {
        if(senha == "senha")
        {
            SC.senhaUser();
        }
        else
        {
            print("error");
        }
    }

    public void Cadastro(string nome)
    {
        SC.nome = nome;
    }

    public void artigo(string i)
    {
        int val;
        bool result = int.TryParse(input.text, out val);
        if (!result)
        {
            return;
        }
        else
        {
            SC.artigo = val;
        }
    }

    public void RespostaNaoFinalizada(string resposta)
    {
       
        SC.respostaNaoFinalizada = resposta;
    }

    public void seleçaoCodigoCivil()
    {
        SC.codigoCivil = dropdown.value;
    }
}
