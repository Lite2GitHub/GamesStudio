using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPickup : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] InteractionController playerInteraction; //temporrary

    public void hover(bool hovering)
    {
        if (hovering)
        {
            sprite.color= Color.gray;
        }
        else
        {
            sprite.color = Color.white;
        }
    }

    public void interact(string context)
    {
        print("collected flower");
        playerInteraction.heldItem = "flower";
        Destroy(gameObject);
    }

    public void LeftRange()
    {
        return;
    }
}
