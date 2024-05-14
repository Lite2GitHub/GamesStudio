using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tear Object", menuName = "Inventory System/Items/Tear")]

public class TearObject : ItemObject
{
    public int numberOfTears;
    public void Awake()
    {
        type = ItemType.Tear;
    }
}
