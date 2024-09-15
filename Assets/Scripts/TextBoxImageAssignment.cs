using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class TextBoxImageAssignment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<SpriteRenderer> symbolHolders = new List<SpriteRenderer>();
    [SerializeField] List<Sprite> symbol = new List<Sprite>();
    [SerializeField] GameObject dialogueBox;
    [SerializeField] SpiritManager spiritManager;

    string tempIndex;
    string currentLetter;
    [SerializeField] List<string> inputSymbolsTrueLen = new List<string>();


    int textFadeIndex;
    bool fadeBool;
    bool startFadeIn;
    int symbolOffset;

    bool symbolsOn;
    bool fadeSymbols;
    private void Start()
    {
        dialogueBox.SetActive(true);
    }

    void Update()
    {
        if (startFadeIn)
        {
            if (fadeBool)
            {
                if (textFadeIndex < symbolHolders.Count && !fadeSymbols)
                {
                    print("coroutine started");
                    StartCoroutine(FadeInText());
                }
                else 
                {
                    spiritManager.OpenJournal();
                    startFadeIn = false;
                    symbolsOn = true;
                }
            }
        }
    }
    public void SetSymbolImages(string inputSymbols)
    {
        currentLetter = "";
        inputSymbolsTrueLen.Clear();

        for (int i = 0; i < inputSymbols.Length; i++)
        {
            if (inputSymbols[i].ToString() == ",")
            {
                inputSymbolsTrueLen.Add(currentLetter);
                currentLetter = "";
            }
            else
            {
                currentLetter += inputSymbols[i].ToString();

                if (i + 1 == inputSymbols.Length)
                {
                    inputSymbolsTrueLen.Add(currentLetter);
                    currentLetter = "";
                }
            }
        }

        symbolOffset = symbolHolders.Count - inputSymbolsTrueLen.Count;

        for (int i = 0; i < symbolHolders.Count; i++)
        {
            if (i < inputSymbolsTrueLen.Count + symbolOffset && i >= symbolOffset)
            {
                tempIndex = inputSymbolsTrueLen[i - symbolOffset].ToString();
                symbolHolders[i].sprite = symbol[int.Parse(tempIndex)];
            }
            else
            {
                symbolHolders[i].sprite = null;
            }
        }
        tempIndex = "";

        startFadeIn = true;
        fadeBool = true;
        textFadeIndex = symbolOffset;

        symbolsOn = true;
    }

    public void FadeOut()
    {
        if (symbolsOn)
        {
            foreach (var symbol in symbolHolders)
            {
                symbol.gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
                FadeOutWait();
            }
            symbolsOn = false;
        }
    }

    IEnumerator FadeOutWait()
    {
        fadeSymbols = true;
        yield return new WaitForSeconds(0.5f);
        fadeSymbols = false;
    }

    IEnumerator FadeInText()
    {
        fadeBool = false;
        symbolHolders[textFadeIndex].GetComponent<Animator>().SetTrigger("FadeIn");
        print("start fade");
        yield return new WaitForSeconds(.75f);
        print("next fade");
        fadeBool = true;
        textFadeIndex++;
    }
}
