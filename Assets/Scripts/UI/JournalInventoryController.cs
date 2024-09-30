using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInventoryController : MonoBehaviour
{
    [SerializeField] List<GameObject> grids = new List<GameObject>();
    [SerializeField] Transform unplacedItemsGO;

    [SerializeField] JournalManager journalManager;

    public void KickAllUnplaced()
    {
        //GridItemInventoryChecker[] flowers = unplacedItemsGO.GetComponentsInChildren<GridItemInventoryChecker>();

        List<GridItemInventoryChecker> flowers = new List<GridItemInventoryChecker>();

        for (int i = 0; i < unplacedItemsGO.childCount; i++)
        {
            flowers.Add(unplacedItemsGO.GetChild(i).GetComponent<GridItemInventoryChecker>());
        }


        foreach (GridItemInventoryChecker flower in flowers)
        {
            if (!flower.placedCorrectly)
            {
                flower.KickFromInventory();
            }
        }

        foreach (GameObject grid in grids)
        {
            grid.GetComponent<ManageGridSquares>().KickFromInventory();
        }
    }

    void CloseInventory()
    {
        journalManager.DeactivateAll();
    }
}
