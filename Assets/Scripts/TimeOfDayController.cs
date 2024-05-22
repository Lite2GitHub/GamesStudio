using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameStateSO gameState;
    [SerializeField] GameObject directionalLight;

    [Header("Variables")]
    [SerializeField] float daySunAngle;
    [SerializeField] float eveningSunAngle;

    bool waitingForFade = false;

    public void UpdateDayTime()
    {
        if (gameState.dayState == 0)
        {
            gameState.dayState = 1;
            waitingForFade = true;
        }
        else
        {
            waitingForFade = true;
            gameState.dayState = 0;
        }
    }

    public void UpdateVisuals()
    {
        if (waitingForFade)
        {
            if (gameState.dayState == 0)
            {
                SetDayVisuals();
            }
            else
            {
                SetEveningVisuals();
            }
            waitingForFade = false;
        }
    }

    void SetDayVisuals()
    {
        ChangeSunDirection(daySunAngle);
    }

    void SetEveningVisuals()
    {
        ChangeSunDirection(eveningSunAngle);
    }

    void ChangeSunDirection(float sunAngle)
    {
        var rot = directionalLight.transform.localRotation.eulerAngles;
        rot.Set(sunAngle, 0f, 0f);
        directionalLight.transform.localRotation = Quaternion.Euler(rot);
    }
}
