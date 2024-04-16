using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // gameobject

    private List<string> items = new List<string>();
    // this stores items as a string, so as a list of names
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

    public bool HasItem(string itemIdentifier) // item checker
    {
        int itemCount = 0;
        foreach (string item in items)
        {
            if (item == itemIdentifier)
            {
                itemCount++;
            }
        }
        return itemCount > 0;
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log(itemName + " added to inventory.");
    }

    public void RemoveItem(string itemIdentifier)
    {
        bool itemRemoved = false; // Flag to track if an item has been removed
        
        for (int i = 0; i < items.Count; i++)
        {
            string item = items[i];
            
            if (items[i] == itemIdentifier)
            {
                items.RemoveAt(i); // Remove the item at index i
                itemRemoved = true;
                return;
            }
        }

        if (itemRemoved)
        {
            Debug.Log("One instance of item with identifier '" + itemIdentifier + "' removed.");
        }
        else
        {
            Debug.Log("Item with identifier '" + itemIdentifier + "' not found in inventory.");
        }
    }
}
