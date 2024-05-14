using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public bool DisplayIsOn = false;
    public Button RemoveButton;

    public void RemoveItem() //giving the 'X' mark the power to remove items from the list
    {
        Destroy(gameObject);

        InventoryManager.Instance.Remove(item);
        
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem() //onClick the items in inventory grid
    {
        if (!DisplayIsOn)
        {
            DisplayIsOn = true;
            InventoryManager.Instance.SetDisplayItem(item);
        }

        if (DisplayIsOn)
        {
            InventoryManager.Instance.ClearDisplayItems();
            DisplayIsOn = false;
        }
    }

    public void Equip()
    {
        if (!DisplayIsOn)
        {
            InventoryManager.Instance.SetEquippedItem(item);
        }
    }

    public void Unequip()
    {
        if (DisplayIsOn)
        {
            InventoryManager.Instance.ClearEquippedSlot();
        }
    }

}