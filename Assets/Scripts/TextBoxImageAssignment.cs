using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Unity.VisualScripting;

public class TextBoxImageAssignment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<SpriteRenderer> symbolHolders = new List<SpriteRenderer>();
    [SerializeField] List<Sprite> symbol = new List<Sprite>();
    [SerializeField] GameObject dialogueBox;

    public void SetSymbolImages(string inputSymbols)
    {
        for (int i = 0; i < symbolHolders.Count; i++)
        {
            if (i < inputSymbols.Length)
            {
                string iLetter = inputSymbols[i].ToString();
                print(int.Parse(iLetter));
                symbolHolders[i].sprite = symbol[int.Parse(iLetter)];
            }
            else
            {
                symbolHolders[i].sprite = null;
            }
        }    
    }

    public void ToggleTextBox(bool shouldHide)
    {
        dialogueBox.SetActive(shouldHide);

        //Color textBoxColor = dialogueBox.GetComponent<SpriteRenderer>().color;
        //textBoxColor.a = 255;
        //dialogueBox.GetComponent<SpriteRenderer>().color = textBoxColor;
    }

    public void FadeTextBox(float duration, bool fadeOut)
    {
        StartCoroutine(FadeOut(duration, dialogueBox.GetComponent<SpriteRenderer>(), fadeOut));

        ////foreach (SpriteRenderer symbol in symbolHolders)
        ////{
        ////    StartCoroutine(FadeOut(duration, symbol, fadeOut));
        ////}

    }

    IEnumerator FadeOut(float fadeDuration, SpriteRenderer target, bool fadeOut)
    {
        Color initialColor = target.color;
        Color targetColor = initialColor;

        float elapsedTime = 0;

        if (fadeOut)
        {
            targetColor.a = 0;
        }
        else
        {
            targetColor.a = 255;
        }

        while (elapsedTime < fadeDuration) 
        {
            elapsedTime += Time.deltaTime;
            dialogueBox.GetComponent<SpriteRenderer>().color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }
        ToggleTextBox(fadeOut);
        print("remove");
    }
}
