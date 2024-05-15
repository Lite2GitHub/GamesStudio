using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    [SerializeField] string targetSceneName;

    void OnTriggerEnter(Collider other)
    {
        sceneController.StartNextScene(targetSceneName);
    }
}
