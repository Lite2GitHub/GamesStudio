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
        sceneController.StartNextScene("SafeLevel");    // Angus changed this; WAS SafeLevel.
    }
    
    public void SettingsMenu()
    {

    }

    public void CreditsMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
