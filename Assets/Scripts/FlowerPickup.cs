using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerPickup : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] Canvas uiCanvas;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material standardMat;
    [SerializeField] Material outlineMat;
    [SerializeField] InteractionController playerInteraction; //temporrary
    [SerializeField] string flowerDialogue;
    [SerializeField] string flowerType;
    [SerializeField] GameObject uiVersion; //UI gameobjkect veriosn of flower for UI drag and drop


    void Start()
    {
        playerInteraction = GameObject.FindGameObjectWithTag("PlayerInteraction").GetComponent<InteractionController>();
        uiCanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
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

        Debug.Log("Pickup success.");

        //instatantiate ui version and remove from parent so it doesn't delete when destroyed
        //The mouse position based on the canvas/screen's coordinate system:
        Vector2 mousePosition = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2)); //mouse origin is bottom left ui is center have to offset

        GameObject uigo = Instantiate(uiVersion);
        uigo.transform.parent = uiCanvas.transform;
        uigo.GetComponent<RectTransform>().anchoredPosition = mousePosition;

        sprite.enabled = false;
    }

    public void LeftRange()
    {
        return;
    }
}
