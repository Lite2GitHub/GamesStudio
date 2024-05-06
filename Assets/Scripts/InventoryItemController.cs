using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public bool DisplayIsOn = false;

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
            DisplayIsOn = true;
        }

        if (DisplayIsOn)
        {
            InventoryManager.Instance.ClearDisplayItems();
            DisplayIsOn = false;
        }

        InventoryManager.Instance.SetDisplayItem(item);
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