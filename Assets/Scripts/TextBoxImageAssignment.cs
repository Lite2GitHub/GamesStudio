using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxImageAssignment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<SpriteRenderer> symbolHolders = new List<SpriteRenderer>();
    [SerializeField] List<Sprite> symbol = new List<Sprite>();
    [SerializeField] GameObject dialogueBox;

    string tempIndex;
    string currentLetter;
    [SerializeField] List<string> inputSymbolsTrueLen = new List<string>();

    public void SetSymbolImages(string inputSymbols)
    {
        currentLetter = "";
        inputSymbolsTrueLen.Clear();

        for (int i = 0; i < inputSymbols.Length; i++)
        {
            print("the input: " + inputSymbols);
            if (inputSymbols[i].ToString() == ",")
            {
                print("the current letter: " + currentLetter);
                inputSymbolsTrueLen.Add(currentLetter);
                currentLetter = "";
            }
            else
            {
                currentLetter += inputSymbols[i].ToString();

                if (i + 1 == inputSymbols.Length)
                {
                    print("the current letter: " + currentLetter);
                    inputSymbolsTrueLen.Add(currentLetter);
                    currentLetter = "";
                }
            }
        }

        for (int i = 0; i < symbolHolders.Count; i++)
        {
            if (i < inputSymbolsTrueLen.Count)
            {
                tempIndex = inputSymbolsTrueLen[i].ToString();
                symbolHolders[i].sprite = symbol[int.Parse(tempIndex)];
            }
            else
            {
                symbolHolders[i].sprite = null;
            }
        }
        tempIndex = "";
    }

    public void ToggleTextBox(bool shouldHide)
    {
        dialogueBox.SetActive(shouldHide);

        Color textBoxColor = dialogueBox.GetComponent<SpriteRenderer>().color;
        textBoxColor.a = 255;
        dialogueBox.GetComponent<SpriteRenderer>().color = textBoxColor;
    }

    public void FadeTextBox(float duration, bool fadeOut)
    {
        StartCoroutine(FadeOut(duration, dialogueBox.GetComponent<SpriteRenderer>(), fadeOut));

        foreach (SpriteRenderer symbol in symbolHolders)
        {
            StartCoroutine(FadeOut(duration, symbol, fadeOut));
        }

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
