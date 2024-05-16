using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseInventory1 : MonoBehaviour
{
    public InventoryObject vaseContainer1;

    private void OnApplicationQuit()    // Make sure inventory is cleansed on Quit (! may not be the case in future)
    {
        vaseContainer1.Container.Clear();
    }



}


