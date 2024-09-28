using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public JournalPageFlipManager journalPageManager; //the journal flip manager script will assign itself as it has a reference to the corner

    public void FlipFinished()
    {
        journalPageManager.JournalPageComplete();
    }
}
