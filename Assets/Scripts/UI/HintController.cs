using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    [SerializeField] GameObject hintPanel;
    [SerializeField] TMP_Text hintText;

    Animator animator;

    void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void GiveHint(string hint)
    {

        print("hint triggered");

        hintPanel.SetActive(true);

        
        hintText.text = hint;

        animator.SetTrigger("Open");
    }

    public void EndHint()
    {
        animator.SetTrigger("Close");
    }

    void DisableHint()
    {
        hintPanel.SetActive(false);
    }
}
