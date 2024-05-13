using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float cameraInitialZ;
    float cameraActualZ;
    public Transform Camera;
    public UIController UI;
    // Start is called before the first frame update
    void Start()
    {
        cameraInitialZ = Camera.position.z;
        cameraActualZ = Camera.transform.position.z;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Camera.position.z < 13.5f)
        {
            cameraActualZ += 0.05f;
            Camera.position = new Vector3(Camera.position.x, Camera.position.y, cameraActualZ);
           
        }
        else
        {
            UI.telaAbertura.SetActive(true);
            this.GetComponent<CameraMovement>().enabled = false;
        }
    }
}
