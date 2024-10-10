using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Progress;

public class SpiritManager : MonoBehaviour, IInteractable
{
    [SerializeField] bool isTotem;

    [Header("References")]
    [SerializeField] IHateMyselfSO hackyData;
    [SerializeField] SpiritManagerSO spiritManagerSO;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject mesh;
    [SerializeField] GameObject doorFractured;
    [SerializeField] GameObject doorFracturedPos;
    [SerializeField] TextBoxImageAssignment dialogueBox;
    [SerializeField] public InteractionController playerInteraction;
    [SerializeField] Material standardMat;
    [SerializeField] Material outlineMat;
    [SerializeField] Animator animator;
    [SerializeField] GameObject stoneVariant;
    [SerializeField] GameObject tear;

    [Header("Dialogue Variables")]
    [SerializeField] List<GameObject> gridList = new List<GameObject>();
    [SerializeField] int flowersRequired;
    [SerializeField] Dictionary<string, string> flowerSymbolsDict = new Dictionary<string, string> {
    { "poppy", "9,3,2"},
    { "daisy", "5,0,11" },
    { "lily", "9,10" },
    { "magnolia", "4,1"},
    { "final", "9,7" } };

    List<string> flowerNames = new List<string> {"poppy", "daisy", "lily", "magnolia" };

    public int dialogueIndex = 0;
    float timerTracker;
    public bool timerActive;
    bool fadeText;
    bool ready = false;
    //bool alive = false;

    public List<string> requiredFlowersList = new List<string>();

    public Item Items;      // Added by Angus

    JournalManager journalManager;


    void Start()
    {
        //GenerateFlowerList();

        playerInteraction = GameObject.FindGameObjectWithTag("PlayerInteraction").GetComponent<InteractionController>();
        journalManager = GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>();

        if (isTotem)
        {
            mesh.GetComponent<Outline>().enabled = false;
        }
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
        if (!hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            if (isTotem)
            {
                if (hovering)
                {
                    mesh.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    mesh.GetComponent<Outline>().enabled = false;
                }
            }
            else
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
        }

    }

    public void interact(string context)
    {
        if (!ready && !hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            spiritManagerSO.spiritOrTotem = gameObject;
            if (dialogueBox!= null)
            {
                animator.SetTrigger("Sigh");
                spiritManagerSO.AddGrid(gridList[dialogueIndex], journalManager.spiritGridParent, this);

                dialogueBox.SetSymbolImages(flowerSymbolsDict[requiredFlowersList[dialogueIndex]]);

                timerTracker = 0;
                timerActive = true;
            }
            else
            {
                spiritManagerSO.AddGrid(gridList[dialogueIndex], journalManager.spiritGridParent, this);
                OpenJournal();
            }
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
        if (dialogueBox!= null) dialogueBox.FadeOut();
    }

    void DialogueLengthTimer(float length)
    {
        if (timerTracker >= length)
        {
            //dialogueBox.FadeTextBox(1, true);
            dialogueBox.FadeOut();
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
        if (dialogueIndex == gridList.Count - 1)
        {
            foreach (string item in contents)
            {
                bool flowerMatches = false;
                foreach (string flower in requiredFlowersList)
                {
                    if (item == flower || item == "leaf")
                    {
                        flowerMatches = true;
                    }
                }
                if (!flowerMatches)
                {
                    print("bouquet contents are incorrect");
                    animator.SetTrigger("Shake");
                    journalManager.CloseFlowerArrange(dialogueIndex);
                    dialogueBox.SetSymbolImages("11,11,11");
                    return;
                }
            }
            journalManager.CloseFlowerArrange(dialogueIndex);
            dialogueIndex++;
            //Destroy(gameObject);
            print("bouquet is correct");

            if (isTotem)
            {
                Instantiate(doorFractured, doorFracturedPos.transform);
                Destroy(doorFracturedPos);
            }
            else
            {
                animator.SetTrigger("Cry");
            }
        }
        else
        {
            foreach (string item in contents)
            {
                if (item != requiredFlowersList[dialogueIndex])
                {
                    print("contents are incorrect");
                    animator.SetTrigger("Shake");
                    return;
                }
            }
            print("contents correct");
            animator.SetTrigger("Nod");
            //journalManager.ClearSpiritGrid();
            dialogueIndex++;
            journalManager.CloseFlowerArrange(dialogueIndex);
        }
    }

    public void TurnToStone()
    {
        print("turned to stone");
        tear.SetActive(true);
        if (stoneVariant != null)
        {
            stoneVariant.SetActive(true);
            Destroy(gameObject);
        }
    }
}
