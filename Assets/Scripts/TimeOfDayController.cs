using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameStateSO gameState;

    public void UpdateDayTime()
    {
        if (gameState.dayState == 0)
        {
            gameState.dayState = 1;
        }
        else
        {
            gameState.dayState = 0;
        }
    }
}
