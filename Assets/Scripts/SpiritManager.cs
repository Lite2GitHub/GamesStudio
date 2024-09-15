using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Progress;

public class SpiritManager : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextBoxImageAssignment dialogueBox;
    [SerializeField] public InteractionController playerInteraction;
    [SerializeField] Material standardMat;
    [SerializeField] Material outlineMat;

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
    bool alive = false;

    public List<string> requiredFlowersList = new List<string>();

    public Item Items;      // Added by Angus

    JournalManager journalManager;


    void Start()
    {
        //GenerateFlowerList();

        playerInteraction = GameObject.FindGameObjectWithTag("PlayerInteraction").GetComponent<InteractionController>();
        journalManager = GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>();
    }

    void Update()
    {
        if (timerActive)
        {
            DialogueLengthTimer(7);
        }
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
        if (!ready)
        {
            dialogueBox.SetSymbolImages(flowerSymbolsDict[requiredFlowersList[dialogueIndex]]);

            timerTracker = 0;
            timerActive = true;

            //if (context != "")
            //{
            //    if (context == requiredFlowersList[dialogueIndex] || requiredFlowersList[dialogueIndex] == "final")
            //    {
            //        dialogueIndex++;
            //        if (dialogueIndex > flowersRequired)
            //        {
            //            ready = true;
            //            Destroy(gameObject);
            //        }
            //        else
            //        {
            //            //add tear stuff
            //            dialogueBox.SetSymbolImages(flowerSymbolsDict[requiredFlowersList[dialogueIndex]]);

            //            timerTracker = 0;
            //            timerActive = true;
            //            playerInteraction.heldItem = "";
            //        }
            //    }
            //    else
            //    {
            //        playerInteraction.heldItem = "";
            //    }
            //}
            //else
            //{
            //    //dialogueBox.FadeTextBox(1, false);

            //}
        }
    }

    public void OpenJournal()
    {
        //dialogueBox.FadeOut(); 
        journalManager.SetFlowerArrangeActive(dialogueIndex);
    }

    public void LeftRange()
    {
        //dialogueBox.FadeTextBox(1, true);
        dialogueBox.FadeOut();
    }

    void DialogueLengthTimer(float length)
    {
        if (timerTracker >= length)
        {
            //dialogueBox.FadeTextBox(1, true);
            dialogueBox.FadeOut();

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

    //void GenerateFlowerList()
    //{
    //    var tempList = flowerNames;
    //    for (int i = 0; i < flowersRequired; i++)
    //    {
    //        var randIndex = tempList[Random.Range(0, tempList.Count)];
    //        requiredFlowersList.Add(randIndex);
    //        tempList.Remove(randIndex);
    //    }

    //    requiredFlowersList.Add("final");
    //}
    
    public void CheckIfFilledCorrectly(List<string> contents)
    {
        if (dialogueIndex == requiredFlowersList.Count - 1)
        {
            foreach (string item in contents)
            {
                bool flowerMatches = false;
                foreach (string flower in requiredFlowersList)
                {
                    if (item == flower || item == "stone")
                    {
                        flowerMatches = true;
                    }
                }
                if (!flowerMatches)
                {
                    print("bouquet contents are incorrect");
                    journalManager.CloseFlowerArrange(dialogueIndex);
                    dialogueBox.SetSymbolImages("11,11,11");
                    return;
                }
            }
            journalManager.CloseFlowerArrange(dialogueIndex);
            Destroy(gameObject);
            print("bouquet is correct");
        }
        else
        {
            foreach (string item in contents)
            {
                if (item != requiredFlowersList[dialogueIndex])
                {
                    print("contents are incorrect");
                    return;
                }
            }
            print("contents correct");
            journalManager.CloseFlowerArrange(dialogueIndex);
            dialogueIndex++;
        }
    }
}
