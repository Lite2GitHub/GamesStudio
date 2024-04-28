using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create New NPC")]

public class NPC : ScriptableObject
{
    public int id; //unique ID, may be useful for combining?
    public string NPCName;
    public string requiredItem;

}
