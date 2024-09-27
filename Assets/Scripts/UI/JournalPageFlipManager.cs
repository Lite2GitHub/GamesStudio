using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPageFlipManager : MonoBehaviour
{
    //get refernce to pages and corners 
    [SerializeField] List<GameObject> pages = new List<GameObject>();
    [SerializeField] Animator leftCorner;
    [SerializeField] Animator rightCorner;

    int pagePosition = 0;

    void Start()
    {
        DeactivateAllPages();
    }

    void TurnPage(int pageIndex)
    {

    }

    void DeactivateAllPages()
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(false); //just to start from sctrach turn off all pages (eventhought they're proably already all off)
        }
    }
}
