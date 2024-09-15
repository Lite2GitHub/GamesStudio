using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Inventory", menuName = "Player Inventory/Create New Inventory")]
public class PlayerInventorySO : ScriptableObject
{
    public List<string> playerInventory = new List<string>();
}
