using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class DataHandler : MonoBehaviour
{
    public List<string[]> rawdata = new List<string[]>();

    private string url =
        "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc0w32YGFx4r_s0IcowPTkmjOr0qzHsM3A1cLo1bYQMH6Z4IA/formResponse";
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

    public void PegarResposta(List<string>res)
    {
        StartCoroutine(Send(res));
    }

    IEnumerator Send(List<string> resp)
    {
        WWWForm form = new WWWForm();
        for (int i = 0; i < resp.Count; i++)
        {
            switch (i)
            {
                case 0:
                    form.AddField("entry.65301063",resp[i]);
                    break;
                case 1:
                    form.AddField("entry.1931470998",resp[i]);
                    break;
                case 2:
                    form.AddField("entry.141025485",resp[i]);
                    break;
                case 3:
                    form.AddField("entry.1806267336",resp[i]);
                    break;
                case 4:
                    form.AddField("entry.134163707",resp[i]);
                    break;
                case 5:
                    form.AddField("entry.163890673",resp[i]);
                    break;
                case 6:
                    form.AddField("entry.750323763",resp[i]);
                    break;
                case 7:
                    form.AddField("entry.250649504",resp[i]);
                    break;
                case 8:
                    form.AddField("entry.821340431",resp[i]);
                    break;
                case 9:
                    form.AddField("entry.1413034820",resp[i]);
                    break;
                case 10:
                    form.AddField("entry.648299047",resp[i]);
                    break;
                case 11:
                    form.AddField("entry.2030424034",resp[i]);
                    break;
                case 12:
                    form.AddField("entry.341881530",resp[i]);
                    break;
            }
        }
        
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
    }
}
