using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaseInventory : MonoBehaviour
{
    Item item;
    public List<Item> VaseItems = new List<Item>();     // List
    public static VaseInventory Instance;

    public Transform Content; //the area to instantiate item (named Content in hier)
    public GameObject InventoryItem; //ref the 2D prefab: Item
    public Toggle EnableRemove;   // Toggle for deleting item

    public GameObject vaseInventoryUI;
    bool vaseInventoryUIVisible = false;
    bool inRange = false;


    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)  // open vase inventory
        {
            if (!vaseInventoryUIVisible)
            {
                Debug.Log("UI open");
                vaseInventoryUI.SetActive(true);
                vaseInventoryUIVisible = true;

                ListItems();
            }
            else
            {
                Debug.Log("UI close");
                vaseInventoryUI.SetActive(false);
                vaseInventoryUIVisible = false;
                CleanContentUI();
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    public void OnTriggerExit(Collider other)   // Currently also closes the UI, can be changed
    {
        Debug.Log("UI close, Out of Range");    // Extra stuff, can leave to close
        inRange = false;
        vaseInventoryUIVisible = false;
        vaseInventoryUI.SetActive(false);
        CleanContentUI();
    }

    public void ListItems()
    {
        foreach (var item in VaseItems)
        {
            GameObject obj = Instantiate(InventoryItem, Content); //Create item/fill out item slot for each item in Item List
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

        // SetInventoryItems();
    }




    public void CleanContentUI()
    {
        // This cleans the content UI which also cleanses the array

        foreach (Transform item in Content)
        {
            Destroy(item.gameObject);
        }
    }

    public void EnableItemsRemove() //For deleteing items in the inventory (button on top right of items)
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in Content)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in Content)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
