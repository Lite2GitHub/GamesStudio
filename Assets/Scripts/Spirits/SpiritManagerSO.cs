using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiritManagerSO", menuName = "creast SpiritManagerSO")]
public class SpiritManagerSO : ScriptableObject
{
    public GameObject activeGrid;
    public GameObject spiritOrTotem;
    
    public void AddGrid(GameObject gridToAdd, Transform parentGO, SpiritManager spiritManager)
    {
        activeGrid = gridToAdd;

        InstantiateGrid(parentGO, spiritManager);
    }


    //these two are public for edge cases but shouldn't need to be called by outsdie scripts

    public void InstantiateGrid(Transform parentGO, SpiritManager spiritManager)
    {
        var gridInst = Instantiate(activeGrid, parentGO);
        gridInst.GetComponent<ManageGridSquares>().spiritManager = spiritManager;
    }
}
