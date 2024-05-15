using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : MonoBehaviour, IInteractable
{
    void Start()
    {
        GetComponent<Outline>().enabled = false;
    }

    public void hover(bool hovering)
    {
        if (hovering)
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
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
