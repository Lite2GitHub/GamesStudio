using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTask : MonoBehaviour
{
    [SerializeField] Sprite taskBoxEmpty;
    [SerializeField] Sprite taskBoxChecked;
    [SerializeField] Image taskBox;

    [SerializeField] TMP_Text description;

    public void CompleteTask()
    {
        taskBox.sprite = taskBoxChecked;
        description.text = "<s>" + description.text + "</s>";
    }
}
