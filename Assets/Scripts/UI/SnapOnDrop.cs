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

            AdjacentSquareManager gridASMRef = eventData.pointerDrag.GetComponent<AdjacentSquareManager>();
            findAllSquaresToFill(gridASMRef);
        }
    }

    //this iterates through all of the adacent squares for the dropped flower
    void findAllSquaresToFill(AdjacentSquareManager gridASMRef)
    {
        //firest fill the current sqaure
        FillSquare();
        
        //for each direction call the fill grid sqaure fucntion for each adjacnet square usuing the count to move the apporariate number of rows or columns
        //if a square has two adjance grids above the square at the same column one row and two rows up need to be filled
        if (gridASMRef.adjacentAbove > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentAbove; i++)
            {
                int targetRow;
                targetRow = row - (i + 1);

                gridSquaresManager.FillGridSquare(targetRow, column);
            }
        }
        else if(gridASMRef.adjacentBelow > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentBelow; i++)
            {
                int targetRow;
                targetRow = row + (i + 1);

                gridSquaresManager.FillGridSquare(targetRow, column);
            }
        }
        else if (gridASMRef.adjacentLeft > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentLeft; i++)
            {
                int targetColumn;
                targetColumn = column - (i + 1);

                gridSquaresManager.FillGridSquare(row, targetColumn);
            }
        }
        else if (gridASMRef.adjacentRight > 0)
        {
            for (int i = 0; i < gridASMRef.adjacentRight; i++)
            {
                int targetColumn;
                targetColumn = column + (i + 1);

                gridSquaresManager.FillGridSquare(row, targetColumn);
            }
        }
    }

    public void FillSquare()
    {
        filled = true;
        GetComponent<Image>().color = Color.black;
    }
}
