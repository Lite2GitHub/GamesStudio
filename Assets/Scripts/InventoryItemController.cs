using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public bool DisplayIsOn = false;

    public Button RemoveButton;


    public void RemoveItem() //giving the 'X' mark the power to remove items from the list
    {
        InventoryManager.Instance.Remove(item);
        VaseInventory.Instance.Remove(item);
        Destroy(gameObject);
    }



    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void DisplayItem()   // On left click
    {

        if (!DisplayIsOn)
        {
            InventoryManager.Instance.SetDisplayItem(item);
            DisplayIsOn = true;
        }

        if (DisplayIsOn)
        {
            InventoryManager.Instance.ClearDisplayItems();
            DisplayIsOn = false;
        }
    }


    //public void Equip()
    //{
    //    if (!DisplayIsOn)
    //    {
    //        InventoryManager.Instance.SetEquippedItem(item);
    //    }
    //}

    //public void Unequip()
    //{
    //    if (DisplayIsOn)
    //    {
    //        InventoryManager.Instance.ClearEquippedSlot();
    //    }
    //}

}