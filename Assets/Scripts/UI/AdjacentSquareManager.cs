using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentSquareManager : MonoBehaviour
{
    public List<GameObject> adjacentAbove = new List<GameObject>();
    public List<GameObject> adjacentBelow = new List<GameObject>();
    public List<GameObject> adjacentLeft = new List<GameObject>();
    public List<GameObject> adjacentRight = new List<GameObject>();

    public void pieceRotationUpdate(bool isClockwise)
    {
        if (isClockwise)
        {
            var tempAbove = adjacentAbove;
            var tempBelow = adjacentBelow;
            var tempLeft = adjacentLeft;
            var tempRight = adjacentRight;

            adjacentAbove = tempLeft;
            adjacentBelow = tempRight;
            adjacentLeft= tempBelow;    
            adjacentRight= tempAbove;
        }
        else
        {
            var tempAbove = adjacentAbove;
            var tempBelow = adjacentBelow;
            var tempLeft = adjacentLeft;
            var tempRight = adjacentRight;

            adjacentAbove = tempRight;
            adjacentBelow = tempLeft;
            adjacentLeft = tempAbove;
            adjacentRight = tempBelow;
        }
    }
}
