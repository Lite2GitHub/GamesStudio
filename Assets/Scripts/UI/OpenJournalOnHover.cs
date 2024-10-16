using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenJournalOnHover : MonoBehaviour, IPointerEnterHandler
{
    [Header("References")]
    [SerializeField] JournalManager journalManager;
    [SerializeField] IHateMyselfSO hackData;

    Animator animator;

    [SerializeField] bool open = false;
    [SerializeField] bool close = false;

    private FMOD.Studio.EventInstance instance;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hackData.openInventoryHoverBook && !open && !hackData.inventoryOpen)
        {
            animator.SetTrigger("Open");
            open = true;
            close = false;
        }
        else if (!hackData.openInventoryHoverBook && !close && open || hackData.inventoryOpen && !close && open)
        {
            animator.SetTrigger("Close");
            close = true;
            open = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            journalManager.SetInventoryActive(true);
        }
        else if (hackData.hackyEventDataItem != null)
        {
            journalManager.SetInventoryActive(true);
        }
    }

    void BookOpened()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/BookOpened");
        instance.start();
        instance.release();
    }
}
