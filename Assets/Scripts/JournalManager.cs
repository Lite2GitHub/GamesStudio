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

    bool vaseUIOpen = false;

    bool isPaused = false;
    private Vector2 origInventoryPos;

    bool inventoryOpen = false;
    bool flowerArrangeOpen = false;

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
                Time.timeScale = 0;
                SetMenuActive();
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
                DeactivateAll();
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab))    // Added by Angus
        {
            if (!inventoryOpen)
            {
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
        Time.timeScale = 1;
        DeactivateAll();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
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
    }
    public void SetInventoryActive()
    {
        inventoryOpen = true;
        //if(!isPaused)
        //{
        //    isPaused = true;
        //    Time.timeScale = 0;
        //}
        backgroundFade.SetActive(true);

        inventory.SetActive(true);

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
        backgroundFade.SetActive(true);

        research.SetActive(true);

        inventory.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetNotesActive()
    {
        backgroundFade.SetActive(true);

        notes.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetMenuActive()
    {
        backgroundFade.SetActive(true);

        menu.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        help.SetActive(false);
    }

    public void SetHelpActive()
    {
        backgroundFade.SetActive(true);

        help.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
    }
}
