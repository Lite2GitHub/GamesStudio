using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [Header("Page References")]
    public GameObject inventory;
    [SerializeField] GameObject research;
    [SerializeField] GameObject notes;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject help;

    //Page animators
    Animator inventoryPageAnimator;

    [Header("References")]
    [SerializeField] SpiritManagerSO spiritManager;
    [SerializeField] SceneController sceneController;
    [SerializeField] GameObject backgroundFade;
    [SerializeField] Animator journalOpenClose;
    public Transform spiritGridParent; //this is just to store the ref so other objects can find as book is pretty much also dissabled

    [SerializeField] IHateMyselfSO hackyData;

    //bool vaseUIOpen = false;    

    bool isPaused = false;
    private Vector2 origInventoryPos;

    bool inventoryOpen = false;
    bool flowerArrangeOpen = false;     

    bool tabbedIn = false;
    bool escapedIn = false;

    string pageOpening; //this stores the desired page so the animation can finsih transitioning

    private FMOD.Studio.EventInstance instance;

    private void Start()
    {
        Vector2 origInventoryPos = inventory.transform.localPosition;

        inventoryPageAnimator = inventory.GetComponent<Animator>();
    }

    void Update()
    {
        if (!hackyData.spiritTalking)
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
                    isPaused = true;
                    SetInventoryActive(true);
                }
                else
                {
                    isPaused = false;
                    DeactivateAll();
                }
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
        if (spiritGridParent.childCount > 0)
        {
            print("close grid");
            Destroy(spiritGridParent.GetChild(0).gameObject);
        }
        journalOpenClose.SetTrigger("Close");
        hackyData.inventoryOpen = false;

        backgroundFade.SetActive(false);
        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);

        inventoryOpen = false;
        //ClearSpiritGrid();

        inventory.GetComponent<JournalInventoryController>().KickAllUnplaced();
    }
    public void SetInventoryActive(bool openDirect)
    {
        if (openDirect)
        {
            journalOpenClose.SetTrigger("Open");
            tabbedIn = true;
            isPaused = true;
        }
        else
        {
            journalOpenClose.SetTrigger("Close");
            journalOpenClose.SetBool("CloseOpen", true);

            tabbedIn = true;
        }
        pageOpening = "inventory";

        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetFlowerArrangeActive(int stage)
    {
        spiritGridParent.GetChild(0).gameObject.SetActive(true);
        inventoryPageAnimator.SetTrigger("Reset");
        flowerArrangeOpen = true;
        print("is the animation going?");
        tabbedIn = false;
        SetInventoryActive(true);
        inventoryPageAnimator.SetBool("GridEnter", true);
    }
    public void CloseFlowerArrange(int stage)
    {
        spiritGridParent.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Close");

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

    public void ClearSpiritGrid()
    {
        for (int i = 0; i < spiritGridParent.childCount; i++)
        {
            Destroy(spiritGridParent.GetChild(i).gameObject);
        }
        
    }
}
