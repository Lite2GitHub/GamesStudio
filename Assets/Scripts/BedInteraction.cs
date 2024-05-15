using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] Material noMat;
    [SerializeField] Material outlineMat;
    public void hover(bool hovering)
    {
        if (hovering)
        {
            GetComponent<MeshRenderer>().material = outlineMat;
            print("outlining");
        }
        else
        {
            GetComponent<MeshRenderer>().material = noMat;
            print("no outlining");
        }
    }

    public void interact(string context)
    {
        throw new System.NotImplementedException();
    }

    public void LeftRange()
    {
        
    }
}
