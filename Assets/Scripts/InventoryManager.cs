using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance; //made into a singleton (?)
    public List<Item> Items = new List<Item>(); //List that stores items

    public Transform ItemContent; //the info of the item
    public GameObject InventoryItem; //this is for the 2D prefab item (?) icon?

    public GameObject InventoryCanvas;
    public bool isInventoryOn;

    public Toggle EnableRemove;

    public Transform DisplayArea; //the display slot
    public GameObject ItemDisplay; //the display prefab

    public Transform HandheldArea; //the equipped slot
    public GameObject EquippedItem; //the equipped prefab

    public InventoryItemController[] InventoryItems;
    /* 
     * this is somehow required to properly remove items i suspect that this array is used 
     * to locate the item in the "Items" list (for Items.Remove(item) to work). Items stored in the 
     * array are GameObjects within the Content UI (real objects vs scriptable objs in the List)
     * 
    */

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isInventoryOn)
            {
                InventoryCanvas.SetActive(true);
                isInventoryOn = true;
                ListItems();
                
            }
            else
            {
                CleanContentUI();
                InventoryCanvas.SetActive(false);
                isInventoryOn = false;
                ItemRemoveToggler();
            }
        }
    }

    public void Add(Item item) //adds items using Item (Scriptable) as the parameter
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems() //this instantiates items onto the Inventory UI (ItemContent) 
    {
        CleanContentUI();

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent); //Create item/fill out item slot for each item in Item List
            var itemName = obj.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }

            var inventoryItemController = obj.GetComponent<InventoryItemController>();
            inventoryItemController.inVase = false;
        }

        SetInventoryItems();
    }

    public void CleanContentUI()
    {
        // This cleans the content UI which also cleanses the array

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    public void EnableItemsRemove() //For deleting items in the inventory (button on top right of items)
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void ItemRemoveToggler()
    {
        // turn the toggle off; to use when menu inventory is turned off
        if (EnableRemove.isOn)
        {
            EnableRemove.isOn = false;
        }
    }


    
    public void SetInventoryItems() //this add the list of items into the inventory's list
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    //public void ClearInventoryItems() //this is causing problems i think
    //{
    //    for (int i = 0; i < InventoryItems.Length - 1; i++)
    //    {
    //        InventoryItems[i].RemoveItem();
    //    }
    //}


    public void SetDisplayItem(Item item) //used in the journal; currently broken
    {

        GameObject obj = Instantiate(ItemDisplay, DisplayArea);
        var itemSprite = obj.transform.Find("ItemSprite").GetComponent<Image>();
        var descriptiveText = obj.transform.Find("DescriptiveText").GetComponent<TMPro.TextMeshProUGUI>();

        itemSprite.sprite = item.icon;
        descriptiveText.text = item.itemDescription;
    }

    public void ClearDisplayItems() //cleanser for display
    {
        if (DisplayArea != null)
        {
            foreach (Transform child in DisplayArea.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    // Unused Code here; tried to make an equip slot
    //public void SetEquippedItem(Item item) //issue here item.icon obj ref not set to an instance
    //{
    //    if (DisplayArea != null)
    //    {
    //        GameObject obj = Instantiate(EquippedItem, HandheldArea);
    //        var itemIcon = obj.transform.Find("ItemEquipIcon").GetComponent<Image>();

    //        itemIcon.sprite = item.icon;
    //    }
    //}

    //public void ClearEquippedSlot()
    //{
    //    foreach (Transform child in HandheldArea.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}
}
