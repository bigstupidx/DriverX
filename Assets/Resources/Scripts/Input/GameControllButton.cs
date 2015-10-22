using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class GameControllButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    bool isUse = false; 


    public void OnPointerDown(PointerEventData eventData)
    {
        isUse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUse = false;
    }

    public bool IsUse()
    {
        return isUse;
    }

    public void SetIsUse(bool val)
    {
        isUse = false;
    }
}
