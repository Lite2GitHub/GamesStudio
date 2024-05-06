using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void interact(string context);

    void hover(bool hovering);

    void LeftRange();
}
