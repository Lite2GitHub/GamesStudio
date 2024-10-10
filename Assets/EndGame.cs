using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneController.StartNextScene("GameEnd");
        }
    }
}
