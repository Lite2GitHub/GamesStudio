using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    public void StartGame()
    {
        sceneController.StartNextScene("Cutscene");
    }

    public void MainMenu()
    {
        sceneController.StartNextScene("MainMenu");
    }

    public void SettingsMenu()
    {

    }

    public void CreditsMenu()
    {
        sceneController.StartNextScene("GameEnd");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
