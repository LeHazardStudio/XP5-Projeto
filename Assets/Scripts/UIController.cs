using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("TELAS INICIAIS")] 
    public List<GameObject> telasInicio;

    [Header("TELAS DO CADERNO")] 
    public GameObject telaInicialDoCaderno;
    [Header("TELAS DE RESPOSTA UNITARIA")]
    public GameObject telaRespostUnit;
    public GameObject telaRespArt;
    public GameObject telaRespSumula;
    [Header("TELAS DE PECA PROCESSUAL")]
    public GameObject telaPeticao;
    [Header("TELAS DE PETICAO ESPECIAL")]
    public GameObject telaPeticaoEspecial;
    public GameObject telaFundEspecial;
    public GameObject telaRespArtPEspecial;
    public GameObject telaRespSumulaPEspecial;
    [Header("TELAS DE PETICAO ORDINARIA")]
    public GameObject telaPeticaoOrdinaria;
    public GameObject TelaFundOrdinaria;
    public GameObject TelaRespArtPOrdinaria;
    public GameObject TelaRespSumulaPOrdinaria;


    [Header("TELA DO JOGO")]
    public GameObject telaJogo;

    [Header("TELAS DO COMPUTADOR")] 
    public GameObject telaComputador;

    private int contadorTelaInicio = 0;

    public void Start()
    {
        telasInicio[contadorTelaInicio].SetActive(true);
    }

    public void AvancarTelaInicio()
    {
        if (contadorTelaInicio == 2)
        {
            telasInicio[contadorTelaInicio].SetActive(false);
            telaJogo.SetActive(true);
        }
        else
        {
            telasInicio[contadorTelaInicio].SetActive(false);
            contadorTelaInicio++;
            telasInicio[contadorTelaInicio].SetActive(true);
        }
    }

    public void JogoTela(int x)
    {
        switch (x)
        {
            case 1:
                telaJogo.SetActive(false);
                telaInicialDoCaderno.SetActive(true);
                break;
            case 2:
                telaJogo.SetActive(false);
                telaComputador.SetActive(true);
                break;
            case 3:
                telaInicialDoCaderno.SetActive(false);
                telaRespostUnit.SetActive(true);
                break;
            case 4:
                telaRespostUnit.SetActive(false);
                telaRespArt.SetActive(true);
                break;
        }
    }

    public void VoltarTelas(int x)
    {
        switch (x)
        {
            case 0:
                telaInicialDoCaderno.SetActive(false);
                telaJogo.SetActive(true);
                break;
            case 1:
                telaComputador.SetActive(false);
                telaJogo.SetActive(true);
                break;
            case 2:
                telaRespostUnit.SetActive(false);
                telaJogo.SetActive(true);
                break;
            case 3:
                telaRespostUnit.SetActive(false);
                telaInicialDoCaderno.SetActive(true);
                break;
            case 4:
                telaRespArt.SetActive(false);
                telaJogo.SetActive(true);
                break;
            case 5:
                telaRespArt.SetActive(false);
                telaRespostUnit.SetActive(true);
                break;
        }
    }
}
