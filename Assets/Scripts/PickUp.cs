using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string itemName;
    public AudioClip pickUpSound;
    private bool playerInRange = false;
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

    private void Update ()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //sounds
            /* 
            if (pickUpSound != null) 
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            } 
            */

            InventoryManager.Instance.AddItem(itemName);
            //"InventoryManager" / "GameManager" future change?

            Debug.Log("Pickup success.");
            Destroy(gameObject);
        }
    }
}