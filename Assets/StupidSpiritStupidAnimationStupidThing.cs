using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidSpiritStupidAnimationStupidThing : MonoBehaviour
{
    [SerializeField] SpiritManager spiritManager;

    void DoneCrying() //I wish
    {
        spiritManager.TurnToStone();
    }
}
