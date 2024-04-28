using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id; //unique ID, may be useful for combining?
    public string itemName;
    public int lifetime; //usually reserved for monetary purposes, should be redundant
    public Sprite icon; //2D image for inventory icon
    public string itemDescription;

    public ItemType itemType; //This is interesting, will probably have to attach traits (or color coded) to each flower

    public enum ItemType //types are labelled as colors for now
    {
        Blue,
        Green,
        Yellow
    }
}
