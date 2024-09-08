using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour
{
    SetParentOnClick setParentOnClick;

    void Start()
    {
        setParentOnClick = GetComponent<SetParentOnClick>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (setParentOnClick.gridParent)
            {
                float angle = setParentOnClick.gridParent.GetComponent<RectTransform>().localEulerAngles.z; //get current angle of the held piece
                angle -= 90; //move 90 deg clock-wise

                setParentOnClick.gridParent.GetComponent<RectTransform>().localEulerAngles = new Vector3(0,0,angle); 
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (setParentOnClick.gridParent)
            {
                float angle = setParentOnClick.gridParent.GetComponent<RectTransform>().localEulerAngles.z; //get current angle of the held piece
                angle += 90; //move 90 deg anti clock-wise

                setParentOnClick.gridParent.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}
