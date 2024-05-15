using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BedInteraction : MonoBehaviour, IInteractable
{
    public GameEvent endOfDay;

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
        endOfDay.TriggerEvent();
    }

    public void LeftRange()
    {
        
    }
}
