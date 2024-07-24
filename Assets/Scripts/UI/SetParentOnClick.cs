using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentOnClick : MonoBehaviour
{
    public GameObject gridParent;

    [SerializeField] List<GameObject> objectArray = new List<GameObject>(); //an array for all the objects to be parent managed

    public void SetNewParent(GameObject newParent)
    {
        gridParent = newParent;

        removeParent();

        foreach (GameObject child in objectArray)
        {
            if (child != newParent)
            {
                Debug.Log("reparented");
                child.transform.SetParent(newParent.transform);
            }
        }

        //transform.SetParent(newParent.transform);

        Debug.Log("reparented");
    }

    //removes the respective managed parent, this object will still remain the main parent
    void removeParent()
    {
        foreach (GameObject child in objectArray)
        {
            child.transform.SetParent(transform);
        }
    }
}
