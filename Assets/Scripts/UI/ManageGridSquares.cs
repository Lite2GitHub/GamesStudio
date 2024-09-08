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

    void Start()
    {
        rowCount = transform.childCount;
        columnCount = transform.GetChild(0).childCount;

        //the grids are first bacthed into rows so make temp array for rows first
        for (int i = 0; i < transform.childCount; i++)
        {
            rowArray.Add(transform.GetChild(i).transform);
        }

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
}
