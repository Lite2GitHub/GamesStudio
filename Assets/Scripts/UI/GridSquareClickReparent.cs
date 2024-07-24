using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSquareClickReparent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] SetParentOnClick parentManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("press");
        parentManager.SetNewParent(gameObject);
    }
}
