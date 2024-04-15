using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueCanvas; // Back story + Prompt
    public GameObject inventoryMenu; // Menu UI 
    public bool playerInRange;
    public PlayerController playerController;
    public InventoryManager playerInventory; // inventory

    public Text interactionText;

    private string requiredItemIdentifier; // Not sure whether to use string or gameobject 
    // private bool isInteracting = false; // redundancy?

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
            Debug.Log("Interact by click work");
            dialogueCanvas.SetActive(true); // open up prompt
            inventoryMenu.SetActive(true); // open up inventory menu
            playerController.SetInteracting(true); // disables player controller
            
            // isInteracting = true; // redundacy 
            
        }
    }

    public void SelectItemFromInventory (string itemIdentifier)
    {
        if (itemIdentifier == requiredItemIdentifier && playerInventory.HasItem(requiredItemIdentifier))
        {
            playerInventory.RemoveItem(requiredItemIdentifier); // correct item taken/consumed
            Debug.Log("Correct item selected & consumed");
            interactionText.text = "spirit is relieved.";
        } 
        else 
        { 
            Debug.Log("Incorrect item selected or player does not have the item required.");
            interactionText.text = "spirit is confused.";
            // enabling the lockdown timer probably starts from here
        }

        CloseMenu();
    }

    void CloseMenu()
    {
        // isInteracting = false;
        playerController.SetInteracting(false); // Enable player movement
        inventoryMenu.SetActive(false);
        interactionText.text = "";
    }

    public void SetRequiredItem(string itemIdentifier)
    {
        requiredItemIdentifier = itemIdentifier;
    }

}
