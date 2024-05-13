using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaAbertura : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TelaOp;
    public GameObject TelaMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FecharTelaAbertura()
    {
        TelaOp.SetActive(false);
        TelaMenu.SetActive(true);
    }
}
