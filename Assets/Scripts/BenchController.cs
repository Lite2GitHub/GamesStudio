using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchController : MonoBehaviour, IInteractable
{
    public GameEvent nextDayPeriod;

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
        nextDayPeriod.TriggerEvent();
    }

    public void LeftRange()
    {

    }
}
