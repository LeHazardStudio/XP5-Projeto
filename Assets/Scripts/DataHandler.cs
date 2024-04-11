using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class DataHandler : MonoBehaviour
{
    public List<string[]> rawdata = new List<string[]>();
    void Start()
    {
        StartCoroutine(Sheet());
        
    }

    IEnumerator Sheet()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/169VdFroMLOg1mQcpZ7sEDJSZLd1chvHy7TGI5EpqVAk/values/Perguntas?key=AIzaSyBgkEX0IODn1kaQc3FefMHAR-1CqVfa4pA");
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            JSONArray values = o["values"].AsArray;
            foreach (JSONArray row in values.Children)
            {
                string[] rowArray = new string[row.Count];
                int i = 0;
                
                foreach (JSONNode cell in row.Children)
                {
                    rowArray[i] = cell.Value;
                    i++;
                }
                rawdata.Add(rowArray);
            }
        }
    }
}
