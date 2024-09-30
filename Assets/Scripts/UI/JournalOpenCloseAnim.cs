using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalOpenCloseAnim : MonoBehaviour
{
    [SerializeField] JournalManager journalManager;

    Animator animator;

    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void OpenFinished()
    {
        journalManager.PageOpenFinished();
        animator.SetBool("CloseOpen", false);
    }

    void BookOpen()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/BookOpened");
        instance.start();
        instance.release();
    }

    void BookClose()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/BookClosed");
        instance.start();
        instance.release();
    }
}
