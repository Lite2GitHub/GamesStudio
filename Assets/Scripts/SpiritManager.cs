using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiritManager : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextBoxImageAssignment dialogueBox;
    [SerializeField] public InteractionController playerInteraction;

    [Header("Dialogue Variables")]
    [SerializeField] int flowersRequired;
    [SerializeField] Dictionary<string, string> flowerSymbolsDict = new Dictionary<string, string> {
    { "poppy", "9,3,2"},
    { "daisy", "5,0,11" },
    { "lily", "9,10" },
    { "magnolia", "4,1"},
    { "final", "9,7" } };

    List<string> flowerNames = new List<string> {"poppy", "daisy", "lily", "magnolia" };

    int dialogueIndex = 0;
    float timerTracker;
    bool timerActive;
    bool fadeText;
    bool ready = false;
    [SerializeField] List<string> requiredFlowersList = new List<string>();

    void Start()
    {
        //dialogueBox.FadeTextBox(0.1f, true);
        dialogueBox.ToggleTextBox(false);

        GenerateFlowerList();

        playerInteraction = GameObject.FindGameObjectWithTag("PlayerInteraction").GetComponent<InteractionController>();
    }

    void Update()
    {
        if (timerActive)
        {
            DialogueLengthTimer(7);
        }

        if (fadeText)
        {
            dialogueBox.FadeTextBox(1f, true);
            fadeText = false;
        }
    }

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

    public void interact(string context)
    {
        if (!ready)
        {
            if (context != "")
            {
                if (context == requiredFlowersList[dialogueIndex] || requiredFlowersList[dialogueIndex] == "final")
                {
                    dialogueIndex++;
                    if (dialogueIndex > flowersRequired)
                    {
                        ready = true;
                        Destroy(gameObject);
                    }
                    else
                    {
                        //add tear stuff
                        dialogueBox.FadeTextBox(1, false);
                        dialogueBox.ToggleTextBox(true);
                        dialogueBox.SetSymbolImages(flowerSymbolsDict[requiredFlowersList[dialogueIndex]]);

                        timerTracker = 0;
                        timerActive = true;
                        playerInteraction.heldItem = "";
                    }
                }
                else
                {
                    playerInteraction.heldItem = "";
                }
            }
            else
            {
                //dialogueBox.FadeTextBox(1, false);
                dialogueBox.ToggleTextBox(true);
                dialogueBox.SetSymbolImages(flowerSymbolsDict[requiredFlowersList[dialogueIndex]]);

                timerTracker = 0;
                timerActive = true;
            }
        }
    }

    public void LeftRange()
    {
        //dialogueBox.FadeTextBox(1, true);
        dialogueBox.ToggleTextBox(false);
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

    void GenerateFlowerList()
    {
        var tempList = flowerNames;
        for (int i = 0; i < flowersRequired; i++)
        {
            var randIndex = tempList[Random.Range(0, tempList.Count)];
            requiredFlowersList.Add(randIndex);
            tempList.Remove(randIndex);
        }

        requiredFlowersList.Add("final");
    }
}