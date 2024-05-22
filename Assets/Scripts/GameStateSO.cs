using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(menuName = "Game State")]
public class GameStateSO : ScriptableObject
{
    public int dayState;

    private void OnEnable()
    {
        dayState = 0;
    }
}
