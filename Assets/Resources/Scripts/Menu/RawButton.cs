using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public abstract class RawButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    protected Button button;

    Texture image1;
    public Texture clickableImage;

	// Use this for initialization
	public void Start () {
        button = GetComponent<Button>();
        image1 = GetComponent<RawImage>().texture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<RawImage>().texture = clickableImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<RawImage>().texture = image1;
    }
}
