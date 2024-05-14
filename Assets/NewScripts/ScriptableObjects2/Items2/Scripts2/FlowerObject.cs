using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Flower Object", menuName = "Inventory System/Items/Flower")]

public class FlowerObject : ItemObject
{
    // public int lifetimeDecay;    // Add when game requires this mech
    public int timeToBloom;
    public void Awake()
    {
        type = ItemType.Flower;
    }
}
