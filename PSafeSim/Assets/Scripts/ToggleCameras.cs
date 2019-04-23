using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameras : MonoBehaviour
{
    private Camera mainCam;
    public Camera shoulderCam;
    private bool isZoomed = false;
    private bool shoulderCamMove = false;
    private Quaternion shoulderCamDefaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam.enabled = true;
        shoulderCam.enabled = false;
        shoulderCamDefaultRotation = shoulderCam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isZoomed == false)
            {
                shoulderCam.transform.rotation = shoulderCamDefaultRotation;
                mainCam.enabled = false;
                shoulderCam.enabled = true;
                isZoomed = true;
            }
            else
            {
                mainCam.enabled = true;
                shoulderCam.enabled = false;
                isZoomed = false;
                shoulderCamMove = false;
            } 
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isZoomed == true)
        {
            if (shoulderCamMove == false)
            {
                shoulderCamMove = true;
            }
            else
            {
                shoulderCamMove = false;
                shoulderCam.transform.rotation = shoulderCamDefaultRotation;
            }
        }
    }

    private void FixedUpdate()
    {
        if (shoulderCamMove == true)
        {
            float hitdist = 0.0f;
            Plane plane = new Plane(Vector3.up, shoulderCam.transform.position);
            Vector3 targetPoint = shoulderCam.ScreenPointToRay(Input.mousePosition).GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - shoulderCam.transform.position);
            shoulderCam.transform.rotation = Quaternion.Slerp(shoulderCam.transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
