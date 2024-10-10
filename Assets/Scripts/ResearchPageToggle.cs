using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPageToggle : MonoBehaviour
{
    [SerializeField] List<Image> pageContents = new List<Image>();

    void Start()
    {
        //foreach (Image image in pageContents)
        //{
        //    image.enabled = false;
        //    print("image off?");
        //}
    }

    public void ActivatePage()
    {
        foreach (Image image in pageContents)
        {
            image.enabled = true;
        }
    }
}
