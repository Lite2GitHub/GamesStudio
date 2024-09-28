using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Hovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Hovering", false);
    }
}
