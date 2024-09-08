using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject occupiedSquare;

    [SerializeField] SetParentOnClick setParentOnClick; //I need this to access all of the grids in the flower, really  bad way to do it but

    RectTransform rectTransform;
    Canvas uiCanvas;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        uiCanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        
        setParentOnClick = GetComponentInParent<SetParentOnClick>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        if (occupiedSquare != null)
        {
            //ClearSquare();

            //clear sqaure for all grids
            foreach (GameObject grid in setParentOnClick.squareArray)
            {
                print("loops throug");
                grid.GetComponent<DragDrop>().ClearSquare();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / uiCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void SetOnSquare(GameObject squareBeingOccupied)
    {
        print("on square");
        occupiedSquare = squareBeingOccupied;
    }

    public void ClearSquare()
    {
        if (occupiedSquare != null)
        {
            occupiedSquare.GetComponent<SnapOnDrop>().EmptySqaure();
            this.occupiedSquare = null;
        }
    }
}
