using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour, IPointerClickHandler
{
    public Item item;

    public bool DisplayIsOn = false;

    public Button RemoveButton;

    public UnityEvent rightClick;   // self explanatory adding right click func to button


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

    public void DisplayItem()   // On left click (default click on item in UI)
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();    // May be redundant
            Debug.Log("right click is Invoked");
            OnRightClick();
            Add2Vase(item);
        }
    }

    public void Add2Vase(Item newItem)
    {
        item = newItem;

    }

    public void OnRightClick()
    {
        VaseInventory.Instance.Add(item);
        InventoryManager.Instance.Remove(item);     // Destroys item from List()
        Destroy(gameObject);
    }

    // Unused equip script test; was thinking of making an equip slot that
    // npcs can check on itme verification (i.e. scan the slot (probs array
    // for if (item == correct) then reward();)
    //
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