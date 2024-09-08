using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContentsManager : MonoBehaviour
{
    [SerializeField] bool isPlayerInventory;
    [SerializeField] PlayerInventorySO playerInventory;

    [SerializeField] List<string> contents = new List<string>();

    public void AddItemToContents(string itemName)
    {
        if (isPlayerInventory)
        {
            playerInventory.playerInventory.Add(itemName);
        }
        contents.Add(itemName);
    }

    public void RemoveFromContents(string itemName)
    {
        print("remove called");
        if (isPlayerInventory)
        {
            playerInventory.playerInventory.Remove(itemName);
        }
        contents.Remove(itemName);
    }
}
