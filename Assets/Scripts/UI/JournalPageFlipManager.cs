using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class JournalPageFlipManager : MonoBehaviour
{
    //get refernce to pages and corners 
    [SerializeField] List<GameObject> pages = new List<GameObject>();
    [SerializeField] GameObject leftCorner;
    [SerializeField] GameObject rightCorner;
    [SerializeField] Animator pageFlip;

    List<GameObject> pageLeftRightNew = new List<GameObject>();
    List<GameObject> pageLeftRightOld = new List<GameObject>();
    int pagePosition = 0; //keeps track of position within pages

    void Start()
    {
        DeactivateAllPages();

        leftCorner.GetComponent<JournalCorner>().journalPageManager = this;
        rightCorner.GetComponent<JournalCorner>().journalPageManager = this;
        pageFlip.GetComponent<PageFlip>().journalPageManager = this;

        FillPageList(pageLeftRightOld);
        pageLeftRightOld[0].SetActive(true); //turn on left page
        pageLeftRightOld[1].SetActive(true); //turn on right page

        CheckActiveCorners(true);
        CheckActiveCorners(false);// slghtly hacky to call twice for both sides but idk seemed fine as itll almost exclusively be used as a one or the other from now on
    }

    public void TurnPage(bool rightPage)
    {
        if (rightPage)
        {
            pagePosition++;

            FillPageList(pageLeftRightNew);

            pageLeftRightNew[1].SetActive(true);
            pageLeftRightNew.RemoveAt(1);
            pageLeftRightOld[1].SetActive(false);
            pageLeftRightOld.RemoveAt(1);

            pageFlip.SetTrigger("FlipPageRight");

            CheckActiveCorners(false); //only check right page 
        }
        else
        {
            pagePosition--;

            FillPageList(pageLeftRightNew);

            pageLeftRightNew[0].SetActive(true);
            pageLeftRightNew.RemoveAt(0);
            pageLeftRightOld[0].SetActive(false);
            pageLeftRightOld.RemoveAt(0);

            pageFlip.SetTrigger("FlipPageLeft");

            CheckActiveCorners(true); //only check left page 
        }
    }

    public void JournalPageComplete()
    {
        pageLeftRightNew[0].SetActive(true);
        pageLeftRightNew.Clear();
        pageLeftRightOld[0].SetActive(false);
        pageLeftRightOld.Clear();

        FillPageList(pageLeftRightOld);

        CheckActiveCorners(true);
        CheckActiveCorners(false);
    }

    void FillPageList(List<GameObject> pageList)
    {
        for (int i = 0; i < pages[pagePosition].transform.childCount; i++)
        {
            pageList.Add(pages[pagePosition].transform.GetChild(i).gameObject);
        }
    }

    void DeactivateAllPages()
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(true); //Make sure the pages themselves are on but will turn of individual child pages

            for (int i = 0; i < page.transform.childCount; i++)
            {
                page.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void CheckActiveCorners(bool onlyCheckLeft)
    {
        if (onlyCheckLeft)
        {
            if (pagePosition > 0)
            {
                leftCorner.SetActive(true);
            }
            else
            {
                leftCorner.SetActive(false);
            }
        }
        else
        {
            if (pagePosition < pages.Count - 1)
            {
                rightCorner.SetActive(true);
            }
            else
            {
                rightCorner.SetActive(false);
            }
        }
    }
}
