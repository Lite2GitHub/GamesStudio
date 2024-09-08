using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenJournalOnHover : MonoBehaviour, IPointerEnterHandler
{
    [Header("References")]
    [SerializeField] JournalManager journalManager;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            journalManager.SetInventoryActive();
        }
    }
}
