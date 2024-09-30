using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTasksManager : MonoBehaviour
{
    [SerializeField] List<GameObject> tasks = new List<GameObject>();
    [SerializeField] RectTransform panel;

    int taskRevealTracker;
    int taskCompleteTracker;

    void Start()
    {
        RevealNextTask();
    }

    public void RevealNextTask()
    {
        tasks[taskRevealTracker].SetActive(true);

        panel.sizeDelta = new Vector2(panel.sizeDelta.x, panel.sizeDelta.y + 55);

        taskRevealTracker++;
    }
    
    public void CompleteNextTask()
    {
        tasks[taskCompleteTracker].GetComponent<ToggleTask>().CompleteTask();

        taskCompleteTracker++;
    }

}
