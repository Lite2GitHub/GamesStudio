using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Xml.Serialization;

public class CameraZoneSwitcher : MonoBehaviour
{
    public string triggerTag;

    public CinemachineVirtualCamera primaryCam;

    public CinemachineVirtualCamera[] virtualCameras;

    private void Start()
    {
        SwitchToCamera(primaryCam);
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
