using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject occupiedSquare;

    [SerializeField] SetParentOnClick setParentOnClick; //I need this to access all of the grids in the flower, really  bad way to do it but
    [SerializeField] GridItemInventoryChecker gridItemInventoryChecker;

    [SerializeField] Transform parentTransform;

    [SerializeField] Sprite regularGrid;
    [SerializeField] Sprite incorrectlyPlacedGrid;

    Transform universalItemHolder;
    RectTransform rectTransform;
    Canvas uiCanvas;
    CanvasGroup canvasGroup;
    Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        uiCanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        universalItemHolder = GameObject.FindGameObjectWithTag("UIItemHolder").GetComponent<Transform>();
        image = GetComponent<Image>();

        //parentTransform = GetComponentInParent<Transform>().GetComponentInParent<Transform>(); //due to the reparenting with the flower grid it needs to grab the parent of the parent
        //print("the parent is: " + parentTransform);

        setParentOnClick = GetComponentInParent<SetParentOnClick>();
        gridItemInventoryChecker = GetComponentInParent<GridItemInventoryChecker>();

        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentTransform.SetParent(universalItemHolder);
        //canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        gridItemInventoryChecker.ResetOnPickup();

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
        //canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        gridItemInventoryChecker.CheckIfPlacedCorrectly();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void SetOnSquare(GameObject squareBeingOccupied)
    {
        print("on square");
        occupiedSquare = squareBeingOccupied;
        SnapOnDrop squareSOD = occupiedSquare.GetComponent<SnapOnDrop>();
        parentTransform.SetParent(squareSOD.itemHolder);
    }

    public void ClearSquare()
    {
        if (occupiedSquare != null)
        {
            occupiedSquare.GetComponent<SnapOnDrop>().EmptySqaure();
            this.occupiedSquare = null;
        }
    }

    public void AddToInventory(string itemName)
    {
        occupiedSquare.GetComponent<SnapOnDrop>().AddItemToInventory(itemName);
    }

    public void RemoveFromInventory(string itemName)
    {
        if (occupiedSquare != null)
        {
            occupiedSquare.GetComponent<SnapOnDrop>().RemoveFromInventory(itemName);
        }
    }

    //call this function from grid item manager script when placed to change if place incorrectly
    public void PlacedStateIndicatorChange(bool placedCorrectly)
    {
        if (placedCorrectly)
        {
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
            image.sprite = regularGrid;
        }
        else
        {
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            image.sprite = incorrectlyPlacedGrid;
        }
    }
}
