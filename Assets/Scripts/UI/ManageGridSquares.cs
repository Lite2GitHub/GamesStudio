using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ManageGridSquares : MonoBehaviour
{
    [SerializeField] bool spiritGrid; //hacky way to get the grid to talk to spirit when full, obviously dont want the players grid to do that
    public int rowCount;
    public int columnCount;
    public bool gridFull;

    //the grids are first bacthed into rows so make temp array for rows first
    [SerializeField] List<Transform> rowArray = new List<Transform>();
    [SerializeField] List<GameObject> gridSqaureArray = new List<GameObject>(); //holds all of the grid squares to manage whats in the inventory

    [SerializeField] Transform itemDraggingHolder;
    [SerializeField] Transform itemHolder;

    [SerializeField] GameObject journalPage;

    [SerializeField] int numberOfActiveSqaures; //serilized for debugging
    [SerializeField] int squaresFilledCount = 0;

    GridContentsManager gridContentsManager;
    SpiritManager spiritManager;

    JournalManager journalManager;

    void Start()
    {
        gridContentsManager = GetComponent<GridContentsManager>();
        spiritManager = GameObject.FindGameObjectWithTag("Spirit").GetComponent<SpiritManager>();
        journalManager = GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>();

        rowCount = rowArray.Count;
        columnCount = rowArray[0].childCount;

        //then iterate through rows to make the grid square array
        for (int i = 0; i < rowArray.Count; i++)
        {
            for (int o = 0; o < rowArray[i].transform.childCount; o++)
            {
                GameObject gridSquare = rowArray[i].GetChild(o).gameObject;
                gridSqaureArray.Add(gridSquare);

                //get reference to the Snap on drop script in order to set row and coloumn and grid manager script ref
                SnapOnDrop childSODRef = gridSquare.GetComponent<SnapOnDrop>();

                childSODRef.gridSquaresManager = this;
                childSODRef.gridContentsManager = gridContentsManager;
                childSODRef.row = i;
                childSODRef.column = o;
                childSODRef.itemHolder = itemHolder;
                childSODRef.journalPage = journalPage.GetComponent<RectTransform>();

                if (childSODRef.active)
                {
                    numberOfActiveSqaures++;
                }
            }
        }
    }

    public void FillGridSquare(int row, int column)
    {
        if (row >= 0 & row < rowCount && column >= 0 && column < columnCount)
        {
            SnapOnDrop gridSqaureToCheck = rowArray[row].GetChild(column).GetComponent<SnapOnDrop>();

            if (gridSqaureToCheck.active && !gridSqaureToCheck.filled)
            {
                gridSqaureToCheck.FillSquare();
            }
        }
    }

    public void SetGridSqaure(int row, int column, GameObject targetSet)
    {
        if (row >= 0 & row < rowCount && column >= 0 && column < columnCount)
        {
            SnapOnDrop gridSqaureToCheck = rowArray[row].GetChild(column).GetComponent<SnapOnDrop>();

            if (gridSqaureToCheck.active && !gridSqaureToCheck.filled)
            {
                gridSqaureToCheck.SetItemSquareActive(targetSet);
            }
        }
    }

    public void CheckForFullGrid()
    {
        squaresFilledCount = 0;
        foreach (GameObject square in gridSqaureArray)
        {
            if (square.GetComponent<SnapOnDrop>().filled)
            {
                squaresFilledCount++;
            }
        }

        if (squaresFilledCount >= numberOfActiveSqaures)
        {
            gridFull = true;
            if (spiritGrid)
            {
                print("sent maybe?");
                spiritManager.CheckIfFilledCorrectly(gridContentsManager.contents);
            }
        }
        else
        {
            gridFull = false;
        }
    }

    public void ClearInventory()
    {
        journalManager.DeactivateAll();
        //print("InventoryCleared");
        //gridContentsManager.ClearContents();
        //for (int i = 0; i < itemHolder.childCount; i++)
        //{
        //    Destroy(itemHolder.GetChild(i).gameObject); 
        //}

        //foreach (GameObject sqr in gridSqaureArray)
        //{
        //    sqr.GetComponent<SnapOnDrop>().filled = false;
        //}

        //gridFull = false;
        //squaresFilledCount = 0;
    }
}
