using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSquareClickReparent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] SetParentOnClick parentManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        ParentOnSelect();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UnparentOnDeselect();
    }

    public void ParentOnSelect()
    {
        parentManager.SetNewParent(gameObject); //adds it as the parent GO in the parent manager
        parentManager.ToggleGrid(true); //turns placement grid on
    }

    public void UnparentOnDeselect()
    {
        parentManager.EmptyParentSlot(); //removes it as the parent GO from the parent manager after a click is done
        parentManager.ToggleGrid(false); //turns placement grid off
    }
}
