using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public bool DisplayIsOn = false;

    public Button RemoveButton;

    public void RemoveItem() //giving the 'X' mark the power to remove items from the list
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem() //onClick the items in inventory grid
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