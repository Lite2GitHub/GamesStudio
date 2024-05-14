using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType    // Future new types of items goes here, such as notes, equipment, KeyItems, etc.
{
    Flower,
    Tear,
    Default
}


public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
