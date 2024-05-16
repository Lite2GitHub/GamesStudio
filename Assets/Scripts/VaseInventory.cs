using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseInventory : MonoBehaviour
{
    Item item;
    public List<Item> VaseItems = new List<Item>();     // List

    public GameObject vaseInventoryUI;
    bool vaseInventoryUIVisible = false;
    bool inRange = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)  // open vase inventory
        {
            if (!vaseInventoryUIVisible)
            {
                Debug.Log("UI open");
                vaseInventoryUI.SetActive(true);
                vaseInventoryUIVisible = true;

            }
            else
            {
                Debug.Log("UI close");
                vaseInventoryUI.SetActive(false);
                vaseInventoryUIVisible = false;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("UI close, Out of Range");    // Extra stuff, can leave to close
        inRange = false;
        vaseInventoryUIVisible = false;
        vaseInventoryUI.SetActive(false);
    }


}
