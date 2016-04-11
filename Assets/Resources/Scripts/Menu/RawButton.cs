using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RawButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Texture image1;
    public Texture clickableImage;
    public Texture disableImage;

    public bool flipDisableX;
    public bool flipDisableY;

    // Use this for initialization
    public void Start () {
        image1 = GetComponent<RawImage>().texture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(GetComponent<Button>().interactable)
        GetComponent<RawImage>().texture = clickableImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
            GetComponent<RawImage>().texture = image1;
    }

    public void DisableButton()
    {
 
        GetComponent<RawImage>().texture = disableImage;

        int coefX = 1;
        int coefY = 1;
        if (flipDisableX)
            coefX = -1;
        if (flipDisableY)
            coefY = -1;

        GetComponent<RawImage>().uvRect = new Rect(0, 0, coefX, coefY);

        GetComponent<Button>().interactable = false;
    }

    public void EnableButton()
    {
        GetComponent<RawImage>().texture = image1;
        GetComponent<RawImage>().uvRect= new Rect(0, 0, 1, 1);
        GetComponent<Button>().interactable = true;
    }

    public bool IsDisabled()
    {
        return GetComponent<Button>().interactable;
    }
}
