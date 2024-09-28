using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalCorner : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public JournalPageFlipManager journalPageManager; //the journal flip manager script will assign itself as it has a reference to the corner

    [SerializeField] bool isRightCorner; //this is used to pass into the turn page fucntion so it knows the travel direction

    [SerializeField] CursorSO cursorData; 

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("Hovering", false);
        print("corner pressed");
        journalPageManager.TurnPage(isRightCorner);
        Cursor.SetCursor(cursorData.defaultCursor, cursorData.universalHotspot, CursorMode.Auto);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("should have grown");
        animator.SetBool("Hovering", true);
        Cursor.SetCursor(cursorData.pickUpHover, cursorData.universalHotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("should have shrunk");
        animator.SetBool("Hovering", false);
        Cursor.SetCursor(cursorData.defaultCursor, cursorData.universalHotspot, CursorMode.Auto);
    }
}
