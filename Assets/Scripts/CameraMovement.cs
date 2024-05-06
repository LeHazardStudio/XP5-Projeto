using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float cameraInitialZ;
    float cameraActualZ;
    public Transform Camera;
    // Start is called before the first frame update
    void Start()
    {
        cameraInitialZ = Camera.position.z;
        cameraActualZ = Camera.transform.position.z;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Camera.position.z < 14)
        {
            cameraActualZ += 0.05f;
            Camera.position = new Vector3(Camera.position.x, Camera.position.y, cameraActualZ);
           
        }
        else
        {
            this.GetComponent<CameraMovement>().enabled = false;
        }
    }
}
