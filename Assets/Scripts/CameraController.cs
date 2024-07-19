using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public bool isPanOut = false;
    public bool isDefault = false;
    public bool isSideCam = false;

    public CinemachineVirtualCamera VirtCamPanOut;
    public CinemachineVirtualCamera VirtCamDefault;
    public CinemachineVirtualCamera VirtCamSide;

    public void CameraCut()
    {
        if (isPanOut)  //Pan Out
        {
            VirtCamPanOut.gameObject.SetActive(true);
            isPanOut = false;

            VirtCamDefault.gameObject.SetActive(false);
            VirtCamSide.gameObject.SetActive(false);
        }

        if (isDefault)    //Default Cam
        {
            VirtCamDefault.gameObject.SetActive(true);
            isDefault = false;

            VirtCamPanOut.gameObject.SetActive(false);
            VirtCamSide.gameObject.SetActive(false);
        }

        if (isSideCam)    //Side Cam
        {
            VirtCamSide.gameObject.SetActive(true);
            isSideCam = false;

            VirtCamDefault.gameObject.SetActive(false);
            VirtCamPanOut.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isPanOut = true;

            isSideCam = false;
            isDefault = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isDefault = true;

            isSideCam = false;
            isPanOut = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isSideCam = true;

            isPanOut = false;
            isDefault = false;
        }
    }

}
