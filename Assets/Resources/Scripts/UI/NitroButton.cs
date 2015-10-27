using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NitroButton : MonoBehaviour {

    Image image;
    Library library;
    bool canActive;

    public Sprite activeSprite;
    public Sprite noActiveSprite;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        library = GameObject.FindObjectOfType<Library>();

        if (activeSprite == null)
            activeSprite = Resources.Load<Sprite>("Images/GUI/Bottom/nitro1");

        if (noActiveSprite == null)
            noActiveSprite = Resources.Load<Sprite>("Images/GUI/Bottom/nitro");

    }
	
	// Update is called once per frame
	void Update () {
	    if(!canActive && library.energy.EnergyEnough())
        {
            canActive = true;
            image.sprite = activeSprite;
        }

        if(canActive && !library.energy.EnergyEnough())
        {
            canActive = false;
            image.sprite = noActiveSprite;
        }
	}
}
