using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapOnDrop : MonoBehaviour, IDropHandler
{
    public bool filled = false;
    public GameObject flowerInSqaure;
    public ManageGridSquares gridSquaresManager;

    public int row;
    public int column;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition -= eventData.pointerDrag.GetComponent<Transform>().parent.GetComponent<RectTransform>().anchoredPosition;

            SetItemSquareActive(eventData.pointerDrag);

            AdjacentSquareManager gridASMRef = eventData.pointerDrag.GetComponent<AdjacentSquareManager>();
            findAllSquaresToFill(gridASMRef);
        }
    }

    //this iterates through all of the adacent squares for the dropped flower
    void findAllSquaresToFill(AdjacentSquareManager gridASMRef)
    {
        //first fill the current sqaure
        FillSquare();

        //for each direction call the fill grid sqaure fucntion for each adjacnet square usuing the count to move the apporariate number of rows or columns
        //if a square has two adjance grids above the square at the same column one row and two rows up need to be filled
        if (gridASMRef.adjacentAbove.Count > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentAbove.Count; i++)
            {
                int targetRow;
                targetRow = row - (i + 1);

                if (targetRow >= 0)
                {
                    gridSquaresManager.SetGridSqaure(targetRow, column, gridASMRef.adjacentAbove[i]);
                    gridSquaresManager.FillGridSquare(targetRow, column);
                }
            }
        }
        
        if(gridASMRef.adjacentBelow.Count > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentBelow.Count; i++)
            {
                int targetRow;
                targetRow = row + (i + 1);

                if (targetRow <= gridSquaresManager.rowCount - 1)
                {
                    gridSquaresManager.SetGridSqaure(targetRow, column, gridASMRef.adjacentBelow[i]);
                    gridSquaresManager.FillGridSquare(targetRow, column);
                }
            }
        }
        
        if (gridASMRef.adjacentLeft.Count > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentLeft.Count; i++)
            {
                int targetColumn;
                targetColumn = column - (i + 1);

                if (targetColumn >= 0)
                {
                    gridSquaresManager.SetGridSqaure(row, targetColumn, gridASMRef.adjacentLeft[i]);
                    gridSquaresManager.FillGridSquare(row, targetColumn);
                }
            }
        }
        
        if (gridASMRef.adjacentRight.Count > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentRight.Count; i++)
            {
                int targetColumn;
                targetColumn = column + (i + 1);

                if (targetColumn <= gridSquaresManager.columnCount - 1)
                {
                    gridSquaresManager.SetGridSqaure(row, targetColumn, gridASMRef.adjacentRight[i]);
                    gridSquaresManager.FillGridSquare(row, targetColumn);
                }
            }
        }
    }

    public void FillSquare()
    {
        filled = true;
        GetComponent<Image>().color = Color.black;
    }

    public void EmptySqaure()
    {
        filled = false;
        GetComponent<Image>().color = Color.white;
    }

    public void SetItemSquareActive(GameObject itemHeld)
    {
        itemHeld.GetComponent<DragDrop>().SetOnSquare(gameObject);
    }
}
