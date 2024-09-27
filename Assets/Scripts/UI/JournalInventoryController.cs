using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInventoryController : MonoBehaviour
{
    [SerializeField] List<GameObject> grids = new List<GameObject>();
    [SerializeField] GameObject unplacedItemsGO;

    public void KickAllUnplaced()
    {
        GridItemInventoryChecker[] flowers = unplacedItemsGO.GetComponentsInChildren<GridItemInventoryChecker>();

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
}
