using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RawBoosterButton : MonoBehaviour
{
    Texture image1;
    public Texture clickableImage;
    public Texture disableImage;
    bool isDisable;

    // Use this for initialization
    public void Start()
    {
        image1 = GetComponent<RawImage>().texture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isDisable)
            GetComponent<RawImage>().texture = clickableImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!isDisable)
            GetComponent<RawImage>().texture = image1;
    }

    public void DisableButton()
    {
        GetComponent<RawImage>().texture = clickableImage;
        isDisable = true;
    }

    public void EnableButton()
    {
        GetComponent<RawImage>().texture = image1;
        isDisable = false;
    }

    public bool IsDisabled()
    {
        return GetComponent<Button>().interactable;
    }
}

