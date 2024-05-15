using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] string targetSceneName;
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
