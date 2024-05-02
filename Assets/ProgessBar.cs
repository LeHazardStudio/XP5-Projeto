using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgessBar : MonoBehaviour
{

#if UNITY_EDITOR
    [MenuItem("GameObject/UI/LinearProgressBar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/LinearProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

    [MenuItem("GameObject/UI/RadialProgressBar")]
    public static void AddRadialProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/RadialProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOfsset = maximum - minimum;
        float fillAmount = currentOffset / maximumOfsset; 
        mask.fillAmount = fillAmount;

        if(fillAmount <= 0.3)
        {
            fill.color = Color.red;
        }
        else if (fillAmount >= 0.7)
        {
            fill.color = Color.green;
        }
        else
        {
            fill.color = Color.yellow;
        }
    }
}
