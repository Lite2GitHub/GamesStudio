using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPickup : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material standardMat;
    [SerializeField] Material outlineMat;
    [SerializeField] InteractionController playerInteraction; //temporrary
    [SerializeField] string flowerDialogue;
    [SerializeField] string flowerType;

    void Start()
    {
        playerInteraction = GameObject.FindGameObjectWithTag("PlayerInteraction").GetComponent<InteractionController>();
    }

    public void hover(bool hovering)
    {
        if (hovering)
        {
            sprite.material = outlineMat;
        }
        else
        {
            sprite.material = standardMat;
        }
    }

    public void interact(string context)
    {
        print("collected flower");
        playerInteraction.heldItem = flowerType;
        Destroy(gameObject);
    }

    public void LeftRange()
    {
        return;
    }
}
