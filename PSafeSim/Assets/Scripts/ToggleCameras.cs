using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameras : MonoBehaviour
{
    private Camera mainCam;
    public Camera zoomCam;
    private bool isZoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam.enabled = true;
        zoomCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isZoomed == false)
            {
                mainCam.enabled = false;
                zoomCam.enabled = true;
                isZoomed = true;
            }
            else
            {
                mainCam.enabled = true;
                zoomCam.enabled = false;
                isZoomed = false;
            }
        }
    }
}
