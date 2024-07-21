using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Xml.Serialization;

public class CameraZoneSwitcher : MonoBehaviour
{
    public string triggerTag;
    public bool isPrimaryCam = true;

    public CinemachineVirtualCamera primaryCam;
    public CinemachineVirtualCamera panOutCam;

    public CinemachineVirtualCamera[] virtualCameras;

    

    private void Start()
    {
        SwitchToCamera(primaryCam);
    }

    private void Update()
    {
        PanFunction();
    }

    public void PanFunction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isPrimaryCam)
            {
                SwitchToCamera(panOutCam);
            }
            else
            {
                SwitchToCamera(primaryCam);
            }
            isPrimaryCam = !isPrimaryCam;
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag(triggerTag))
        {
            CinemachineVirtualCamera targetCamera = player.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCamera);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag(triggerTag))
        {
            SwitchToCamera(primaryCam);
            isPrimaryCam = true;
        }
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera cam in virtualCameras) 
        {
            cam.enabled = cam == targetCamera;
        }
    }
}
