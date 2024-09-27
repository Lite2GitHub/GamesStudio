using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "hack_data", menuName = "hack_data")]
public class IHateMyselfSO : ScriptableObject
{
    public GameObject hackyEventDataItem;
    public float value = 0;

    public bool inventoryOpen = false;
}
