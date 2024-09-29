using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    void PlayerStepped()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/FootStep");
        instance.start();
        instance.release();
    }
}
