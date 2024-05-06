using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiritManager : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextBoxImageAssignment dialogueBox;
    [SerializeField] string[] dialogueList;
    [SerializeField] public InteractionController playerInteraction;

    int dialogueIndex = 0;
    float timerTracker;
    bool timerActive;
    bool fadeText;
    bool ready = false;

    void Start()
    {
        //dialogueBox.FadeTextBox(0.1f, true);
        dialogueBox.ToggleTextBox(false);
    }

    void Update()
    {
        if (timerActive)
        {
            DialogueLengthTimer(5);
        }

        //if (fadeText)
        //{
        //    dialogueBox.FadeTextBox();
        //    //fadeText = false;
        //}
    }

    public void hover(bool hovering)
    {
        if (hovering)
        {
            sprite.color = Color.gray;
        }
        else
        {
            sprite.color = Color.black;
        }
    }

    public void interact(string context)
    {
        if (!ready)
        {
            switch (context)
            {
                case "flower":
                    dialogueIndex++;
                    if (dialogueIndex > dialogueList.Length - 1)
                    {
                        ready = true;
                    }
                    else
                    {
                        //add tear stuff
                        //dialogueBox.FadeTextBox(1, false);
                        dialogueBox.ToggleTextBox(true);
                        dialogueBox.SetSymbolImages(dialogueList[dialogueIndex]);

                        timerTracker = 0;
                        timerActive = true;
                        playerInteraction.heldItem = "";
                    }
                    break;
                case "":
                    //dialogueBox.FadeTextBox(1, false);
                    dialogueBox.ToggleTextBox(true);
                    dialogueBox.SetSymbolImages(dialogueList[dialogueIndex]);

                    timerTracker = 0;
                    timerActive = true;
                    break;
            }
        }
    }

    public void LeftRange()
    {
        //dialogueBox.FadeTextBox(1, true);
        dialogueBox.ToggleTextBox(false);
        if (ready)
        {
            Destroy(gameObject);
        }
    }

    void DialogueLengthTimer(float length)
    {
        if (timerTracker >= length)
        {
            //dialogueBox.FadeTextBox(1, true);
            dialogueBox.ToggleTextBox(false);

            if (ready)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timerTracker += Time.deltaTime;
        }
    }
}
