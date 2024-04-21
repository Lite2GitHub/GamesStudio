using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem() //giving the 'X' mark the power to remove items from the list
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem() //I have no idea whats happening, just add in the types i guess
    {
        switch (item.itemType)
        {
            case Item.ItemType.Blue:
                break;
            case Item.ItemType.Green:
                break;
            case Item.ItemType.Yellow:
                break;
        }
        
        RemoveItem();
    }

}
