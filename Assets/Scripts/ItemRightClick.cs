using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemRightClick : MonoBehaviour, IPointerClickHandler
{
    Item item;
    
    public UnityEvent rightClick;   // self explanatory adding right click func to button

    public Button InventoryItemAsButton;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
            RightClick();
            // Works on the button yes
        }
    }

    public void RightClick()    // On right click; works its attached to script
    {
        VaseInventory.Instance.Add(item);
        Destroy(gameObject);
    }




}
