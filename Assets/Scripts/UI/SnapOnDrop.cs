using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapOnDrop : MonoBehaviour, IDropHandler
{
    public bool filled = false;
    public GameObject flowerInSqaure;
    public ManageGridSquares gridSquaresManager;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition -= eventData.pointerDrag.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition;

            gridSquaresManager.ItemDroppedOnGrid(eventData.pointerDrag); //pass up the item dopped up to the manager so it can cycle trhough every grid to see where else it overlaps
        }
    }

    public void CheckForOverlap(GameObject flowerDropped)
    {
        if (GetComponent<RectTransform>().rect.Overlaps(flowerDropped.GetComponent<RectTransform>().rect))
        {
            print("overlaps");
            filled = true;
            flowerInSqaure = flowerDropped;
        }
        else
        {
            print("doesn't overlaps");
        }
    }
}
