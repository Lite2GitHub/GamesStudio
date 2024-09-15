using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItemInventoryChecker : MonoBehaviour
{
    [SerializeField] string flowerType;

    [SerializeField] Image flowerImage;

    public bool placedCorrectly;

    SetParentOnClick setParentOnClick; //just to get all sqaure references, I should fix this
    List<GameObject> sqaureRefs = new List<GameObject>();

    void Start()
    {
        setParentOnClick = GetComponent<SetParentOnClick>();
        sqaureRefs = setParentOnClick.squareArray;
    }

    public void CheckIfPlacedCorrectly()
    {
        foreach (GameObject sqaure in sqaureRefs)
        {
            if (sqaure.GetComponent<DragDrop>().occupiedSquare == null)
            {
                print("a null");
                flowerImage.color = Color.red;
                placedCorrectly = false; 
                return;
            }
        }
        print("no null");
        placedCorrectly = true;
        flowerImage.color = Color.white;

        setParentOnClick.squareArray[0].GetComponent<DragDrop>().AddToInventory(flowerType);
    }

    public void ResetOnPickup()
    {
        placedCorrectly = false;
        flowerImage.color = Color.white;

        setParentOnClick.squareArray[0].GetComponent<DragDrop>().RemoveFromInventory(flowerType);
    }
}
