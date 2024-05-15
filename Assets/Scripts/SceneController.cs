using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameEvent loadNextLevel;

    string nextSceneName;
    public void StartNextScene(string sceneName)
    {
        nextSceneName = sceneName;
        loadNextLevel.TriggerEvent();
    }

    public void LoadNextScene()
    {
        if (nextSceneName != "" && nextSceneName != null)
        {
            SceneManager.LoadScene(nextSceneName);
            nextSceneName = "";
        }
    }
}
