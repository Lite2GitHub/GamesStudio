using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id; //unique ID, may be useful in future.
    public string itemName;
    // public int lifetime; // feature to be added.
    public Sprite icon; //2D image for inventory icon

    [TextArea (5, 20)]
    public string itemDescription;

    // public ItemType itemType; //This is interesting, will probably have to attach traits (or color coded) to each flower

    //public enum ItemType //types are labelled as colors for now   // could be useful /Doubt/
    //{
    //    Blue,
    //    Green,
    //    Yellow
    //}
}
