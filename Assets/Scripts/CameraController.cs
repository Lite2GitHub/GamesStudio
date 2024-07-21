using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Switch;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    [SerializeField]
    private CinemachineVirtualCamera vCam1; //DefaultCam

    [SerializeField]
    private CinemachineVirtualCamera vCam2; //PanOutCam

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private bool defaultCam = true;


    private void Start()
    {
        action.performed += _ => SwitchPriority();  // "_" is to pass a parameter? this case there is nothing so...
        //subscribing to action called SwitchPriority (aka this script will listen for input (= action.performed))
    }

    private void SwitchPriority()
    {
        if (defaultCam)
        {
            vCam1.Priority = 0;
            vCam2.Priority = 1;
        }   
        else
        {
            vCam1.Priority = 1;
            vCam2.Priority = 0;
        }
        defaultCam = !defaultCam;
    }



}
