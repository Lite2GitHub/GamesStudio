using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentSquareManager : MonoBehaviour
{
    public int adjacentAbove;
    public int adjacentBelow;
    public int adjacentLeft;
    public int adjacentRight;

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
