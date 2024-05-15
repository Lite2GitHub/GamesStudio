using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour, IInteractable
{
    [SerializeField] string targetSceneName;
    void Start()
    {
        GetComponent<Outline>().enabled = false;
    }

    public void hover(bool hovering)
    {
        if (hovering)
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }

    public void interact(string context)
    {
        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
    }

    public void LeftRange()
    {
        
    }
}
