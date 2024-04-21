using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id; //unique ID, may be useful for combining?
    public string itemName;
    public int value; //usually reserved for monetary purposes, should be redundant
    public Sprite icon; //2D image for inventory icon
}
