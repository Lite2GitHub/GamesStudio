using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour, IPointerClickHandler
{
    Item item;

    public UnityEvent rightClick;   // self explanatory adding right click func to button

    public bool DisplayIsOn = false;

    public Button RemoveButton;
    public Button InventoryItemAsButton;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
            // Works on the button yes
        }
    }


    public void RemoveItem() //giving the 'X' mark the power to remove items from the list
    {
        InventoryManager.Instance.Remove(item);
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

    public void RightClick()    // On right click; works its attached to script
    {
        
        
        RemoveItem();

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