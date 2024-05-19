using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarTela : MonoBehaviour
{
    public GameObject TelasCaderno;
    public GameObject telaPC;
    public UIController ui;
    public GameObject pcButton;
    public GameObject barraScore;
    public GameObject TelasIniciais;

    public GameObject Camera;

    private bool caderno = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TelaPiscar()
    {
        barraScore.SetActive(true);
        if (!caderno)
        {
            Camera.transform.position = new Vector3(35.62f, -8.11f, 14.8f);
            Camera.transform.rotation = Quaternion.Euler(90,0,0);
            Camera.GetComponent<Camera>().fieldOfView = 55.1f;
            TelasCaderno.SetActive(true);
            ui.CadernoGeneralImagem.SetActive(true);
            ui.JogoTela(17);
            pcButton.SetActive(true);
            caderno = true;
            TelasIniciais.SetActive(false);
            telaPC.SetActive(false);
        }
        else
        {
            Camera.transform.position = new Vector3(36.84f, -8f, 13.5f);
            Camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            Camera.GetComponent<Camera>().fieldOfView = 78.5f;
            ui.CadernoGeneralImagem.SetActive(false);
            TelasCaderno.SetActive(false);
            ui.VoltarTelas(5);
            pcButton.SetActive(false);
            caderno = false;
            telaPC.SetActive(true);
            TelasIniciais.SetActive(true);
        }
        barraScore.SetActive(false);
     
    }

    void desativarBarra()
    {
        this.gameObject.SetActive(false);
    }
}
