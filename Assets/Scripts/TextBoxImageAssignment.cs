using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxImageAssignment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<Image> interactableObjects = new List<Image>();
    [SerializeField] List<Image> symbol = new List<Image>();

    public void SetSymbolImages(string inputSymbols)
    {
        for (int i = 0; i < inputSymbols.Length; i++)
        {
            interactableObjects[i] = symbol[i];
        }
    }
}
