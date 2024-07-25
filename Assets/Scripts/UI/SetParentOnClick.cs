using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentOnClick : MonoBehaviour
{
    public GameObject gridParent;

    [SerializeField] List<GameObject> objectArray = new List<GameObject>(); //an array for all the objects to be parent managed

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

        Debug.Log("reparented");
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
}
