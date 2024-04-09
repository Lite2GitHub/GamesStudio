using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private List<string> inventoryItems = new List<string>();
    // this stores items as a string/list
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps the inventory manager alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);
        Debug.Log(itemName + " added to inventory.");
    }

    public void RemoveItem(string itemName)
    {
        inventoryItems.Remove(itemName);
        Debug.Log(itemName + " removed from inventory.");
    }

    public bool HasItem(string itemName) //Gives others access to check if certain items exist in list, to be used by other scripts
    {
        return inventoryItems.Contains(itemName);
    }

}
