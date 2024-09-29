using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalOpenCloseAnim : MonoBehaviour
{
    [SerializeField] JournalManager journalManager;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void OpenFinished()
    {
        journalManager.PageOpenFinished();
        animator.SetBool("CloseOpen", false);
    }
}
