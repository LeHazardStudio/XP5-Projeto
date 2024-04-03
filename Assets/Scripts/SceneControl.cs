using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public string nome;
    public int artigo;
    public string respostaNaoFinalizada;
    public string respostaFundamentada;
    public int codigoCivil;


    public int telaAtual;
    public int telaAtualdoCaderno;

    public List<GameObject> screens;
    // Start is called before the first frame update
    void Start()
    {
        returnToMenu();
        telaAtualdoCaderno = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModoUser()
    {
        screenChanger(1);
    }

    public void senhaUser()
    {
        screenChanger(2);
    }

    public void cadastroConfirmar()
    {
        screenChanger(3);
        StartCoroutine(tutorial());
    }

    public IEnumerator tutorial()
    {
        yield return new WaitForSeconds(3);
        screenChanger(4);
    }

    public void selecionarCaderno()
    {
        screenChanger(telaAtualdoCaderno);
    }

    public void RespostaUnitaria()
    {
        screenChanger(6);
        telaAtualdoCaderno = 6;
    }

    public void PeçaProcessual()
    {
        print("peça processuou");
        telaAtualdoCaderno = 9;
    }

    public void voltarDoCaderno()
    {
        screenChanger(4);
    }

    public void voltarGeral()
    {
        screenChanger(telaAtual - 1);
        telaAtualdoCaderno--;
    }
    public void returnToMenu()
    {
        screenChanger(0);
    }

    public void Artigo()
    {
        print("artigou");
        telaAtualdoCaderno = 7;
        screenChanger(7);
    }

    public void Sumula()
    {
        print("Sumulou");
        telaAtualdoCaderno = 8;
        //screenChanger(8);
    }

    public void FinalizarResposta()
    {
        respostaFundamentada = respostaNaoFinalizada;
    }





    public void deactiveAllScreens()
    {
        
        foreach (GameObject i in screens)
        {
            i.SetActive(false);
        }
    }

    public void screenChanger(int x)
    {
        deactiveAllScreens();
        screens[x].SetActive(true);
        telaAtual = x;
    }
}
