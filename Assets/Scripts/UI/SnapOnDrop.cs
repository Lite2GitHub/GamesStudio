using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapOnDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("flow dropped on sq2uare");
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Parent pos: " + eventData.pointerDrag.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition -= eventData.pointerDrag.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
