using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPickup : MonoBehaviour, IInteractable
{
    public void interact()
    {
        print("collected flower");
        Destroy(gameObject);
    }
}
