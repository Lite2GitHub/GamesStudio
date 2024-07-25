using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSquareClickReparent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] SetParentOnClick parentManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("press");
        parentManager.SetNewParent(gameObject); //adds it as the parent GO in the parent manager
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        parentManager.EmptyParentSlot(); //removes it as the parent GO from the parent manager after a click is done
        Debug.Log("remove parent");
    }
}
