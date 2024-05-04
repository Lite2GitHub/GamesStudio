using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance; //made into a singleton (?)
    public List<Item> Items = new List<Item>(); //List that stores items

    public Transform ItemContent; //the info of the item
    public GameObject InventoryItem; //this is for the 2D prefab item (?) icon?

    public Toggle EnableRemove;

    public Transform DisplayArea; //the display slot
    public GameObject ItemDisplay; //the display prefab

    public Transform HandheldArea; //the equipped slot
    public GameObject EquippedItem; //the equipped prefab

    public InventoryItemController[] InventoryItems; //array?

    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item) //adds items using Item (Scriptable) as the parameter
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        // This cleans the content UI?
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

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

        }

        SetInventoryItems();
    }

    public void EnableItemsRemove() //For deleteing items in the inventory (button on top right of items)
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

    public void SetDisplayItem(Item item) //used in the journal
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

    public void SetEquippedItem(Item item)
    {
        if (DisplayArea != null) //WHAT THE FUCK IS WRONNGGGG?????
        {
            
            GameObject obj = Instantiate(EquippedItem, HandheldArea);
            var itemIcon = obj.transform.Find("ItemEquipIcon").GetComponent<Image>();

            itemIcon.sprite = item.icon; //APPARENTLY THIS LINE BUT THEY ARE ALL IDENTICAL WHY FAIL NOW?
            
            

        }
    }

    public void ClearEquippedSlot()
    {
        foreach (Transform child in HandheldArea.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
