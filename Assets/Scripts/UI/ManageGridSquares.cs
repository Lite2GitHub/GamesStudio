using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGridSquares : MonoBehaviour
{
    [SerializeField] List<GameObject> gridSqaureArray = new List<GameObject>(); //holds all of the grid squares to manage whats in the inventory

    void Start()
    {
        //the grids are first bacthed into rows so make temp array for rows first
        List<Transform> tempRowArray = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            tempRowArray.Add(transform.GetChild(i).transform);
        }

        //then iterate through rows to make the grid square array
        foreach (Transform row in tempRowArray)
        {
            for (int i = 0; i < row.transform.childCount; i++)
            {
                GameObject gridSquare = row.GetChild(i).gameObject;
                gridSqaureArray.Add(gridSquare);
                gridSquare.GetComponent<SnapOnDrop>().gridSquaresManager = this;
            }
        }
    }

    public void ItemDroppedOnGrid(GameObject flowerDropped)
    {
        print("flower dropped");
        foreach (GameObject gridSqaure in gridSqaureArray)
        {
            gridSqaure.GetComponent<SnapOnDrop>().CheckForOverlap(flowerDropped);
        }
    }
}
