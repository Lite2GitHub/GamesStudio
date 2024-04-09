using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public string reqItemName = "Key";
    public GameObject dialogueCanvas; //Back story + Prompt
    public bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Mouse1)) //right click to interact
        {
            dialogueCanvas.SetActive(true); //open up prompt


            if (InventoryManager.Instance.HasItem(reqItemName))
            {
                // Player has the required item, initiate dialogue for giving the item
                
            }
            else
            {
                // Player does not have the required item, display a message or do nothing
            }
        }
    }

}
