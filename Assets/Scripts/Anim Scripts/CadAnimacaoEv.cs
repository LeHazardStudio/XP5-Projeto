using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadAnimacaoEv : MonoBehaviour
{
    public UIController UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AbrirCadernoGeral()
    {
        UI.telaInicialDoCaderno.SetActive(true);
        UI.telaRespostUnit.SetActive(false);
    }

    void AbrirCadernoUnitaria()
    {
        UI.telaRespostUnit.SetActive(true);
    }

    void AbrirCadernoPeticao()
    {
        UI.telaPeticao.SetActive(true);
        UI.telaRespostUnit.SetActive(false);
    }

   /* void FecharCadernoGeral()
    {
        UI.telaInicialDoCaderno.SetActive(false);
        UI.telaFundEspecial.SetActive(false);
        UI.telaPeticaoEspecial.SetActive(false);
        UI.telaPeticao.SetActive(false);
        UI.telaPeticaoOrdinaria.SetActive(false);
        UI.telaRespArt.SetActive(false);
        UI.telaRespArtPEspecial.SetActive(false);
        UI.TelaRespArtPOrdinaria.SetActive(false);
        UI.telaRespSumula.SetActive(false);
        UI.telaRespSumulaPEspecial.SetActive(false);
        UI.TelaRespSumulaPOrdinaria.SetActive(false);
        UI.TelaFundOrdinaria.SetActive(false);
        UI.telaRespostUnit.SetActive(false);
        UI.CadernoGeneralImagem.SetActive(false);
    }*/

}
