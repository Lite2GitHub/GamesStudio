using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [Header("Page References")]
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject research;
    [SerializeField] GameObject notes;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject help;

    //Page animators
    Animator inventoryPageAnimator;

    [Header("Hackey Spirit Flower Arrangements")]
    [SerializeField] List<GameObject> spiritGrids = new List<GameObject>();

    [Header("References")]
    [SerializeField] SceneController sceneController;
    [SerializeField] GameObject backgroundFade;
    [SerializeField] Animator journalOpenClose;

    [SerializeField] IHateMyselfSO hackyData;

    bool vaseUIOpen = false;

    bool isPaused = false;
    private Vector2 origInventoryPos;

    bool inventoryOpen = false;
    bool flowerArrangeOpen = false;

    bool tabbedIn = false;
    bool escapedIn = false;

    string pageOpening; //this stores the desired page so the animation can finsih transitioning

    private void Start()
    {
        Vector2 origInventoryPos = inventory.transform.localPosition;

        inventoryPageAnimator = inventory.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                escapedIn = true;
                SetMenuActive();
            }
            else
            {
                isPaused = false;
                DeactivateAll();
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (!inventoryOpen)
            {
                tabbedIn = true;
                SetInventoryActive();
            }
            else
            {
                DeactivateAll();
                inventoryOpen = false;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        DeactivateAll();
    }

    public void BackToMainMenu()
    {
        isPaused = false;
        DeactivateAll();
        sceneController.StartNextScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Tab functions

    public void DeactivateAll()
    {
        journalOpenClose.SetTrigger("Close");
        hackyData.inventoryOpen = false;

        backgroundFade.SetActive(false);
        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);

        foreach (GameObject spiritGrid in spiritGrids)
        {
            spiritGrid.SetActive(false);
        }

        inventory.GetComponent<JournalInventoryController>().KickAllUnplaced();
    }
    public void SetInventoryActive()
    {
        if (tabbedIn)
        {
            journalOpenClose.SetTrigger("Open");
        }
        else
        {
            journalOpenClose.SetTrigger("Close");
            journalOpenClose.SetBool("CloseOpen", true);
        }
        pageOpening = "inventory";

        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetFlowerArrangeActive(int stage)
    {
        spiritGrids[stage].SetActive(true);
        inventoryPageAnimator.SetTrigger("Reset");
        flowerArrangeOpen = true;
        print("is the animation going?");
        SetInventoryActive();
        inventoryPageAnimator.SetBool("GridEnter", true);
    }
    public void CloseFlowerArrange(int stage)
    {
        spiritGrids[stage].GetComponent<Animator>().SetTrigger("Close");
        flowerArrangeOpen = false;
        print("is the animation going?");
        inventoryPageAnimator.SetBool("GridEnter", false);
    }

    public void SetResearchActive()
    {
        journalOpenClose.SetTrigger("Close");
        journalOpenClose.SetBool("CloseOpen", true);
        pageOpening = "research";

        backgroundFade.SetActive(true);

        inventory.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetNotesActive()
    {
        journalOpenClose.SetTrigger("Close");
        journalOpenClose.SetBool("CloseOpen", true);

        pageOpening = "notes";

        backgroundFade.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetMenuActive()
    {
        if (escapedIn)
        {
            journalOpenClose.SetTrigger("Open");
            escapedIn = false;
        }
        else
        {
            journalOpenClose.SetTrigger("Close");
            journalOpenClose.SetBool("CloseOpen", true);
        }

        pageOpening = "menu";


        hackyData.inventoryOpen = true;

        backgroundFade.SetActive(true);


        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        help.SetActive(false);
    }

    public void SetHelpActive()
    {
        journalOpenClose.SetTrigger("Close");
        journalOpenClose.SetBool("CloseOpen", true);

        backgroundFade.SetActive(true);

        pageOpening = "help";

        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
    }

    public void PageOpenFinished()
    {
        switch (pageOpening)
        {
            case "inventory":
                hackyData.inventoryOpen = true;
                inventoryOpen = true;
                backgroundFade.SetActive(true);
                inventory.SetActive(true);
                if (!tabbedIn)
                {
                    inventoryPageAnimator.SetBool("GridEnter", true);
                }
                else
                {
                    tabbedIn = false;
                }
                return;
            case "research":
                research.SetActive(true);
                return;
            case "notes":
                notes.SetActive(true);
                return;
            case "menu":
                menu.SetActive(true);
                return;
            case "help":
                help.SetActive(true);
                return;
        }
    }
}
