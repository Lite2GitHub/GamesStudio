using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    Image image;
    public void Awake()
    {
        image = GetComponent<Image>();
    }
    public void FadeIn()
    {
        var newColor = image.color;
        newColor.a = 255;

        image.color = newColor;
    }

    public void FadeOut()
    {
        var newColor = image.color;
        newColor.a = 0;

        image.color = newColor;
    }
}
