using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    Item item; //this line gives access to Item.cs as "Item"
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

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        //sounds
        /* 
        if (pickUpSound != null) 
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
        } 
        */

        InventoryManager.Instance.Add(item);
        Destroy(gameObject);

        Debug.Log("Pickup success.");
    }
}