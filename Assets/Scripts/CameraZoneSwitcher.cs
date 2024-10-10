using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Xml.Serialization;

public class CameraZoneSwitcher : MonoBehaviour
{
    //public string triggerTag;
    public bool isPrimaryCam;

    public CinemachineVirtualCamera primaryCam;
    public CinemachineVirtualCamera crumbleCam;
    public CinemachineVirtualCamera panOutPlainsCam;

    public CinemachineVirtualCamera[] virtualCameras;

    

    private void Start()
    {
        SwitchToCamera(primaryCam);
        isPrimaryCam = true;
    }

    private void Update()
    {
        //PanFunction();
        //CrumbleFunction();
        CameraController();
    }

    //public void PanFunction()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        if (isPrimaryCam)
    //        {
    //            SwitchToCamera(panOutPlainsCam);
    //        }
    //        else
    //        {
    //            SwitchToCamera(primaryCam);
    //        }
    //        isPrimaryCam = !isPrimaryCam;
    //    }
    //}

    //public void CrumbleFunction()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        if (isPrimaryCam)
    //        {
    //            SwitchToCamera(crumbleCam);
    //        }
    //        else
    //        {
    //            SwitchToCamera(primaryCam);
    //        }
    //        isPrimaryCam = !isPrimaryCam;
    //    }
    //}

    public void CameraController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToCamera(primaryCam);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToCamera(crumbleCam);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchToCamera(panOutPlainsCam);
        }
    }

    //private void OnTriggerEnter(Collider player)
    //{
    //    if (player.CompareTag(triggerTag))
    //    {
    //        CinemachineVirtualCamera targetCamera = player.GetComponentInChildren<CinemachineVirtualCamera>();
    //        SwitchToCamera(targetCamera);
    //    }
    //}

    //private void OnTriggerExit(Collider player)
    //{
    //    if (player.CompareTag(triggerTag))
    //    {
    //        SwitchToCamera(primaryCam);
    //        isPrimaryCam = true;
    //    }
    //}

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera cam in virtualCameras) 
        {
            cam.enabled = cam == targetCamera;
        }
    }
}
