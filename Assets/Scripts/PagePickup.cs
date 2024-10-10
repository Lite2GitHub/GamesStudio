using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePickup : MonoBehaviour, IInteractable
{
    [SerializeField] IHateMyselfSO hackyData;

    [SerializeField] List<GameObject> pagesToDelete = new List<GameObject>();

    [Header("References")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material standardMat;
    [SerializeField] Material outlineMat;
    [SerializeField] string pageFlower;
    [SerializeField] CursorSO cursorData;

    HintController hintController;

    JournalManager journalManager;
    JournalPageFlipManager journalPageFlipManager;

    void Start()
    {
        hintController = GameObject.FindGameObjectWithTag("Hint").GetComponent<HintController>();

        GameObject journalGO = GameObject.FindGameObjectWithTag("Journal");
            
        journalManager = journalGO.GetComponent<JournalManager>();
        journalPageFlipManager = journalGO.GetComponent<Transform>().GetChild(2).GetComponent<JournalPageFlipManager>();
    }

    public void hover(bool hovering)
    {
        if (!hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            if (hovering)
            {
                sprite.material = outlineMat;

                Cursor.SetCursor(cursorData.pickUpHover, cursorData.universalHotspot, CursorMode.Auto);
            }
            else
            {
                sprite.material = standardMat;
                Cursor.SetCursor(cursorData.defaultCursor, cursorData.universalHotspot, CursorMode.Auto);
            }
        }
    }

    public void interact(string context)
    {
        if (!hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            if (pagesToDelete.Count > 0)
            {
                foreach (GameObject page in pagesToDelete)
                {
                    Destroy(page);
                }
            }

            hintController.GiveHint(pageFlower + " research page added");

            journalManager.SetResearchActive(true);

            journalPageFlipManager.AddPage(pageFlower);

            Destroy(gameObject);
        }
    }

    public void LeftRange()
    {
        return;
    }
}
