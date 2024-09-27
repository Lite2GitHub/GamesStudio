using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenJournalOnHover : MonoBehaviour, IPointerEnterHandler
{
    [Header("References")]
    [SerializeField] JournalManager journalManager;
    [SerializeField] IHateMyselfSO hackData;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            journalManager.SetInventoryActive();
        }
        else if (hackData.hackyEventDataItem != null)
        {
            journalManager.SetInventoryActive();
        }
    }
}
