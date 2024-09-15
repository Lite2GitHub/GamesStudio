using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentSquareManager : MonoBehaviour
{
    public List<GameObject> neigbouringSquares = new List<GameObject>();
    public List<string> neigbouringCoords = new List<string>();

    public void pieceRotationUpdate(bool isClockwise)
    {
        if (neigbouringSquares.Count > 0)
        {
            if (isClockwise)
            {
                for (int i = 0; i < neigbouringSquares.Count; i++)
                {
                    var rowColumnCoords = neigbouringCoords[i].Split(',');
                    int row = int.Parse(rowColumnCoords[0]);
                    int column = int.Parse(rowColumnCoords[1]);

                    int newRow = -column;
                    int newColumn = row;

                    neigbouringCoords[i] = newRow.ToString() + "," + newColumn.ToString();
                }
            }
            else
            {
                for (int i = 0; i < neigbouringSquares.Count; i++)
                {
                    var rowColumnCoords = neigbouringCoords[i].Split(',');
                    int row = int.Parse(rowColumnCoords[0]);
                    int column = int.Parse(rowColumnCoords[1]);

                    int newRow = column;
                    int newColumn = -row;

                    neigbouringCoords[i] = newRow.ToString() + "," + newColumn.ToString();
                }
            }
        }
    }
}
