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

    GameObject journalPage;

    [SerializeField] int numberOfActiveSqaures; //serilized for debugging
    [SerializeField] int squaresFilledCount = 0;

    GridContentsManager gridContentsManager;

    JournalManager journalManager;

    public SpiritManager spiritManager; // this gets set whne the grid is instantiated

    [SerializeField] IHateMyselfSO hackData;

    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        gridContentsManager = GetComponent<GridContentsManager>();
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
                childSODRef.journalPage = journalManager.inventory.GetComponent<RectTransform>();
                childSODRef.hackyData = hackData;

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
                if (gridSqaureToCheck.isTearLocked)
                {
                    if (targetSet.GetComponent<DragDrop>().flowerType == "Tear")
                    {
                        gridSqaureToCheck.SetItemSquareActive(targetSet);
                        FillGridSquare(row, column);
                    }
                }
                else
                {
                    gridSqaureToCheck.SetItemSquareActive(targetSet);
                    FillGridSquare(row, column);
                }
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

    public void KickFromInventory()
    {
        GridItemInventoryChecker[] flowers = itemHolder.GetComponentsInChildren<GridItemInventoryChecker>();

        foreach (GridItemInventoryChecker flower in flowers)
        {
            if (!flower.placedCorrectly)
            {
                flower.KickFromInventory();
                FlowerDrop();
            }
        }
    }

    public void ForceKickAll()
    {
        GridItemInventoryChecker[] flowers = itemHolder.GetComponentsInChildren<GridItemInventoryChecker>();

        foreach (GridItemInventoryChecker flower in flowers)
        {

            flower.KickFromInventory();
            FlowerDrop();
        }
    }

    void FlowerDrop()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/FlowerFail");
        instance.start();
        instance.release();
    }
}
