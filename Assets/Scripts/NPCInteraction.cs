using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    Item Item;

    public GameObject dialogueCanvas; // Back story + Prompt
    public GameObject inventoryMenu; // Menu UI 
    public GameObject successDialogue;
    public GameObject failDialogue;


    public bool playerInRange;
    public PlayerController playerController;

    public GameObject requiredItem;
    public GameObject selectedItem;
    private bool correctItemReceived = false;

    private bool isMenuUIOpen = false;

    public Text interactionText;

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
            dialogueCanvas.SetActive(true); // dialogue only, prompt to open inventory with [Tab]
            playerController.SetInteracting(true); // disables player controller
            inventoryMenu.SetActive(true);
            // isInteracting = true; // redundacy 

            if (!correctItemReceived && selectedItem == requiredItem )
            {
                correctItemReceived = true;
                successDialogue.SetActive(true);
            } 
            else
            {
                correctItemReceived = false;
                failDialogue.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape)) // can add other methods of exitting
        {
            UnlockPlayer();
        }
    }

    void UnlockPlayer()
    {
        // isInteracting = false;
        playerController.SetInteracting(false); // Enable player movement
        inventoryMenu.SetActive(false);
        isMenuUIOpen = false;
        dialogueCanvas.SetActive(false);
    }


}
