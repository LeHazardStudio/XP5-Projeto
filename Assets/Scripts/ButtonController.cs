using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponent<Animator>().SetInteger("Anim", 1);

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponent<Animator>().SetInteger("Anim", 0);

    }

    
}
