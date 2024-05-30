using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [Header("Page References")]
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject research;
    [SerializeField] GameObject notes;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject help;

    [Header("References")]
    [SerializeField] SceneController sceneController;

    //bool vaseUIOpen = false;

    bool isPaused = false;
    private Vector2 origInventoryPos;

    private void Start()
    { 
        origInventoryPos = inventory.transform.position;
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
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                SetInventoryActive();
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
                DeactivateAll();
            }
        }

        // Vase inventory shifting inventory to right; numbers are wack due to Unity but it is adjusted.

        if (VaseInventory.Instance.vaseInventoryUIVisible == true)
        {
            inventory.transform.position = new Vector2(920, 270);
        }
        else
        {
            inventory.transform.position = origInventoryPos;
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
        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }
    public void SetInventoryActive()
    {
        inventory.SetActive(true);

        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetResearchActive()
    {
        research.SetActive(true);

        inventory.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetNotesActive()
    {
        notes.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        menu.SetActive(false);
        help.SetActive(false);
    }

    public void SetMenuActive()
    {
        menu.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        help.SetActive(false);
    }

    public void SetHelpActive()
    {
        help.SetActive(true);

        inventory.SetActive(false);
        research.SetActive(false);
        notes.SetActive(false);
        menu.SetActive(false);
    }
}
