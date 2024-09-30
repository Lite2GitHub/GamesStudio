using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTasksManager : MonoBehaviour
{
    [SerializeField] List<GameObject> tasks = new List<GameObject>();
    [SerializeField] RectTransform panel;

    int taskRevealTracker;
    int taskCompleteTracker;

    private FMOD.Studio.EventInstance instance;

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
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/BookOpened");
        instance.start();
        instance.release();

        tasks[taskCompleteTracker].GetComponent<ToggleTask>().CompleteTask();

        taskCompleteTracker++;
    }

}
