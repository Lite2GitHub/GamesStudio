using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ManageGridSquares : MonoBehaviour
{
    public int rowCount;
    public int columnCount;

    //the grids are first bacthed into rows so make temp array for rows first
    [SerializeField] List<Transform> rowArray = new List<Transform>();
    [SerializeField] List<GameObject> gridSqaureArray = new List<GameObject>(); //holds all of the grid squares to manage whats in the inventory

    [SerializeField] bool gridFull;
    [SerializeField] int squaresFilledCount = 0;

    GridContentsManager gridContentsManager;

    void Start()
    {
        gridContentsManager = GetComponent<GridContentsManager>();

        rowCount = rowArray.Count;
        columnCount = transform.GetChild(0).childCount;

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
            }
        }
    }

    public void FillGridSquare(int row, int column)
    {
        rowArray[row].GetChild(column).GetComponent<SnapOnDrop>().FillSquare();
    }

    public void SetGridSqaure(int row, int column, GameObject targetSet)
    {
        rowArray[row].GetChild(column).GetComponent<SnapOnDrop>().SetItemSquareActive(targetSet);
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

        if (squaresFilledCount >= gridSqaureArray.Count)
        {
            gridFull = true;
        }
        else
        {
            gridFull = false;
        }
    }
}
