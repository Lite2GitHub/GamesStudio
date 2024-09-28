using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CursorData", menuName = "create CursorData")]

public class CursorSO : ScriptableObject
{
    public Texture2D defaultCursor;
    public Texture2D pickUpHover;
    public Texture2D pickUpGrab;
    public Texture2D dialogue;

    public Vector2 universalHotspot;
}
