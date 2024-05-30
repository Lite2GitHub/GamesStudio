//using UnityEngine;
//using UnityEngine.UI;

//public class NPCInteraction : MonoBehaviour
//{
//    Item Item;
//    NPC NPC;

//    public GameObject dialogueCanvas; // Back story + Prompt
//    public GameObject successDialogue;
//    public GameObject failDialogue;


//    public bool playerInRange;
//    public PlayerController playerController;


//    private NPC ItemRequired;
//    public GameObject ItemSelected; //to be changed 
//    private bool correctItemReceived = false;

//    private bool isMenuUIOpen = false;

//    public Text interactionText;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerInRange = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerInRange = false;
//        }
//    }

//    private void Update()
//    {
//        if (playerInRange && Input.GetKeyDown(KeyCode.Mouse1)) //right click to interact
//        {
//            Debug.Log("Interact by click work");
//            dialogueCanvas.SetActive(true); // dialogue only, prompt to open inventory with [Tab]
//            playerController.SetInteracting(true); // disables player controller
//            // isInteracting = true; // redundacy 

//            if (!correctItemReceived && ItemSelected == ItemRequired)
//            {
//                correctItemReceived = true;
//                successDialogue.SetActive(true);
//            } 
//            else
//            {
//                correctItemReceived = false;
//                failDialogue.SetActive(true);
//            }

//        }

//        if (Input.GetKeyDown(KeyCode.Escape)) // can add other methods of exitting
//        {
//            UnlockPlayer();
//        }
//    }

//    void UnlockPlayer()
//    {
//        // isInteracting = false;
//        playerController.SetInteracting(false); // Enable player movement
//        isMenuUIOpen = false;
//    }

    
//}     UNUSED SCRIPTS
