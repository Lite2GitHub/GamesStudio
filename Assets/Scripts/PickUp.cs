using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string itemName = "GreenFlower"; //Name of flower
    
    public AudioClip pickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

            Destroy(gameObject);

        }
    }
}
