using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    // Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    public float cameraVerticalRotation = 0f;
    public float cameraHorizontalRotation = 0f;

    bool lockedCursor = false;


    void Start()
    {


    }


    void Update()
    {
        // Collect Mouse Input

        if (!lockedCursor)
        {

            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            if (inputY != 0)
            {
                cameraHorizontalRotation -= inputX;
                cameraHorizontalRotation = Mathf.Clamp(cameraHorizontalRotation, -45, 45);
                cameraVerticalRotation -= inputY;
                cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -45, 45);
                transform.localEulerAngles = Vector3.right * cameraVerticalRotation + Vector3.down * cameraHorizontalRotation;
            }

        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }


    }

    public void changeCursorState()
    {
        if (!lockedCursor)
        {
            lockedCursor = true;
        }
        else
        {
            lockedCursor = false;
        }
    }
}