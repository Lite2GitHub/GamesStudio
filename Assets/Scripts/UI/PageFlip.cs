using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public JournalPageFlipManager journalPageManager; //the journal flip manager script will assign itself as it has a reference to the corner

    private FMOD.Studio.EventInstance instance;

    public void FlipFinished()
    {
        journalPageManager.JournalPageComplete();
    }

    void BookPageTurn()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/BookPageTurn");
        instance.start();
        instance.release();
    }
}
