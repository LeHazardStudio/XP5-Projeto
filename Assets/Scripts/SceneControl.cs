using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public DataHandler data;
    public TMP_Text questao;
    public void SetQuestion(int x)
    {
        questao.text = data.rawdata[x][0];
    }
}
    
   
