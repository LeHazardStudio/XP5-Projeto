using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            case 0:
                telaJogo.SetActive(false);
                telaInicialDoCaderno.SetActive(true);
                break;
            case 1:
                telaJogo.SetActive(false);
                telaComputador.SetActive(true);
                break;
            case 2:
                telaInicialDoCaderno.SetActive(false);
                telaRespostUnit.SetActive(true);
                break;
            case 3:
                telaInicialDoCaderno.SetActive(false);
                telaPeticao.SetActive(true);
                break;
            case 4:
                telaRespostUnit.SetActive(false);
                telaRespArt.SetActive(true);
                break;
            case 5:
                telaRespostUnit.SetActive(false);
                telaRespSumula.SetActive(true);
                break;
            case 6:
                telaPeticao.SetActive(false);
                telaPeticaoEspecial.SetActive(true);
                break;
            case 7:
                telaPeticao.SetActive(false);
                telaPeticaoOrdinaria.SetActive(true);
                break;
            case 8:
                telaPeticaoEspecial.SetActive(false);
                telaFundEspecial.SetActive(true);
                break;
            case 9:
                telaFundEspecial.SetActive(false);
                telaRespArtPEspecial.SetActive(true);
                break;
            case 10:
                telaFundEspecial.SetActive(false);
                telaRespSumulaPEspecial.SetActive(true);
                break;
            case 11:
                telaPeticaoOrdinaria.SetActive(false);
                TelaFundOrdinaria.SetActive(true);
                break;
            case 12:
                TelaFundOrdinaria.SetActive(false);
                TelaRespArtPOrdinaria.SetActive(true);
                break;
            case 13:
                TelaFundOrdinaria.SetActive(false);
                TelaRespSumulaPOrdinaria.SetActive(true);
                break;
        }
    }

    public void VoltarTelas(int x)
    {
        //switch (x)
        //{
            
        //}
    }
}
