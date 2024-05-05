using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritManager : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    public void hover(bool hovering)
    {
        if (hovering)
        {
            sprite.color = Color.gray;
        }
        else
        {
            sprite.color = Color.white;
        }
    }

    public void interact()
    {
        //display dialogue
    }
}
