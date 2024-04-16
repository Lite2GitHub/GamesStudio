using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentifier : MonoBehaviour
{
    public string identifier; // Unique identifier for the item

    // This script is mainly used to attach an unique ID to every flower

    // additional things:
    // public int itemValue;
    // public Sprite itemIcon;

    // Example method to interact with the item
    public void Interact()
    {
        Debug.Log("Item interacted: " + identifier);
        // Add logic here for item interaction, such as using the item, equipping, etc.
    }
}
