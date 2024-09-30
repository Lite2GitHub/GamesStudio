using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetParentOnClick : MonoBehaviour
{
    public GameObject gridParent;
    public List<GameObject> squareArray = new List<GameObject>(); //not ideal but an array for the squares to control the grid

    [SerializeField] List<GameObject> objectArray = new List<GameObject>(); //an array for all the objects to be parent managed
    [SerializeField] Sprite regularGrid;

    bool showGrid = false; //turns off grid based on whether the piece is held currently


    [SerializeField] IHateMyselfSO hackData;
    [SerializeField] GameObject inWorldFlower;

    [SerializeField] CursorSO cursorData;

    //loop through the grid sqaures to hand down references (wish I did this with more things and sooner but too late now)
    private void Awake()
    {
        foreach (GameObject grid in squareArray)
        {
            var gridDragDrop = grid.GetComponent<DragDrop>();

            gridDragDrop.hackData = hackData;
            gridDragDrop.inWorldFlower = inWorldFlower;
            gridDragDrop.cursorData = cursorData;
            gridDragDrop.flowerType = GetComponent<GridItemInventoryChecker>().flowerType;
        }
    }

    //other objects call this function with a referecne to themselves
    public void SetNewParent(GameObject newParent)
    {
        removeParent(); //remove the parent GO and any hierachy

        gridParent = newParent;

        foreach (GameObject child in objectArray)
        {
            //add as child of the parent GO
            if (child != newParent)
            {
                child.transform.SetParent(newParent.transform);
            }
        }

        //transform.SetParent(newParent.transform);
    }

    //removes the respective managed parent, this object will still remain the main parent
    void removeParent()
    {
        gridParent = null; //empty parent slot

        //iterate through loop and make a child of this GO inorder to remove existing parent structure a reset basically
        foreach (GameObject child in objectArray)
        {
            child.transform.SetParent(transform);
        }
    }

    //Public function grid squares can call to stop any lingering references
    public void EmptyParentSlot()
    {
        gridParent = null; //empty parent slot
    }

    public void ToggleGrid(bool turnOn)
    {
        if (turnOn)
        {
            foreach (GameObject child in squareArray)
            {
                Image tempImage = child.GetComponent<Image>();
                tempImage.sprite = regularGrid;
                var tempColor = tempImage.color;
                tempColor.a = 1f;
                tempImage.color = tempColor;
            }
        }
        else
        {
            foreach (GameObject child in squareArray)
            {
                Image tempImage = child.GetComponent<Image>();
                var tempColor = tempImage.color;
                tempColor.a = 0f;
                tempImage.color = tempColor;
            }
        }
    }
}
