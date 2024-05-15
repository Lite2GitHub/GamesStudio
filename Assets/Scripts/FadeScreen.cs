using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameEvent fadeOutDone;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void FadeOut()
    {
        animator.SetTrigger("Fade_Out");
    }

    public void FadeIn()
    {
        animator.SetTrigger("Fade_In");
    }

    public void FadeOutDone()
    {
        fadeOutDone.TriggerEvent();
    }
}
