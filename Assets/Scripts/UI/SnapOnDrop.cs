using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapOnDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool active = true;

    public bool filled = false;
    public GameObject flowerInSqaure;
    public ManageGridSquares gridSquaresManager;
    public GridContentsManager gridContentsManager;
    public Transform itemHolder;

    public int row;
    public int column;

    public RectTransform journalPage; 
    
    public IHateMyselfSO hackyData;


    [SerializeField] RectTransform gridParent; //these are set in editor incase of strange grid setups
    [SerializeField] RectTransform rowParent; //these are set in editor incase of strange grid setups

    Image image;

    void Start()
    {
        image = GetComponent<Image>();

        if (!active)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }

        //journalPage = GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>().inventory.GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (active || !filled)
        {
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + gridParent.anchoredPosition + rowParent.anchoredPosition + journalPage.anchoredPosition;

               
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition -= eventData.pointerDrag.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition;


                SetItemSquareActive(eventData.pointerDrag);

                AdjacentSquareManager gridASMRef = eventData.pointerDrag.GetComponent<AdjacentSquareManager>();

                if (gridASMRef.neigbouringSquares.Count > 0) 
                {
                    findAllSquaresToFill(gridASMRef);
                }
                else
                {
                    FillSquare();
                    gridSquaresManager.CheckForFullGrid();
                }
            }
        }
    }

    //this iterates through all of the adacent squares for the dropped flower
    void findAllSquaresToFill(AdjacentSquareManager gridASMRef)
    {
        //first fill the current sqaure
        FillSquare();

        //for each direction call the fill grid sqaure fucntion for each adjacnet square usuing the count to move the apporariate number of rows or columns
        //if a square has two adjance grids above the square at the same column one row and two rows up need to be filled

        for (int i = 0; i < gridASMRef.neigbouringSquares.Count; i++)
        {
            var rowColumnCoords = gridASMRef.neigbouringCoords[i].Split(',');
            int rowOffset = int.Parse(rowColumnCoords[0]);
            int columnOffset = int.Parse(rowColumnCoords[1]);

            int targetRow = row - rowOffset;
            int targetColumn = column + columnOffset;

            gridSquaresManager.SetGridSqaure(targetRow, targetColumn, gridASMRef.neigbouringSquares[i]);
            gridSquaresManager.FillGridSquare(targetRow, targetColumn);
        }

        gridSquaresManager.CheckForFullGrid();
    }

    public void FillSquare()
    {
        filled = true;
        //GetComponent<Image>().color = Color.black;
    }

    public void EmptySqaure()
    {
        filled = false;
        GetComponent<Image>().color = Color.white;
        gridSquaresManager.CheckForFullGrid();
    }

    public void SetItemSquareActive(GameObject itemHeld)
    {
        itemHeld.GetComponent<DragDrop>().SetOnSquare(gameObject);
    }

    public void AddItemToInventory(string itemName)
    {
        gridContentsManager.AddItemToContents(itemName);
    }

    public void RemoveFromInventory(string itemName)
    {
        gridContentsManager.RemoveFromContents(itemName);
    }


    //this bit doesn't exist 
    bool checkForMouseUp = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hackyData.hackyEventDataItem != null)
        {
            checkForMouseUp = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        checkForMouseUp = false;
    }

    bool doOnceHack = false;
    void Update()
    {
        if (checkForMouseUp)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameObject itemPlacing = hackyData.hackyEventDataItem;
                hackyData.hackyEventDataItem = null;

                //snap the item to this grids position
                itemPlacing.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + gridParent.anchoredPosition + rowParent.anchoredPosition + journalPage.anchoredPosition;
                itemPlacing.GetComponent<RectTransform>().anchoredPosition -= itemPlacing.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition;


                SetItemSquareActive(itemPlacing);

                AdjacentSquareManager gridASMRef = itemPlacing.GetComponent<AdjacentSquareManager>();

                if (gridASMRef.neigbouringSquares.Count > 0)
                {
                    findAllSquaresToFill(gridASMRef);
                }
                else
                {
                    FillSquare();
                    gridSquaresManager.CheckForFullGrid();
                }

                itemPlacing.GetComponent<DragDrop>().CheckIfPlaced();
            }
        }
    }
}
