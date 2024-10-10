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

    bool showingHint = false;

    void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void GiveHint(string hint)
    {
        if (showingHint)
        {
            EndHint();
        }

        print("hint triggered");

        hintPanel.SetActive(true);

        
        hintText.text = hint;

        animator.SetTrigger("Open");

        showingHint = true;
    }

    public void EndHint()
    {
        animator.SetTrigger("Close");
        showingHint= false;
    }

    void DisableHint()
    {
        hintPanel.SetActive(false);
    }
}
