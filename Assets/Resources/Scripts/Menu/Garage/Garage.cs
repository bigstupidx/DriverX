using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Garage : MonoBehaviour {

    CarChanger carChanger;
    LibraryMenu libraryMenu;

    public Button buyButton;
    public Button playButton;

    public Filling filling;

	// Use this for initialization
	void Start () {
        carChanger = transform.GetComponentInChildren<CarChanger>();
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToDefault()
    {
        carChanger.ToDefault();
        //libraryMenu.fireStart.GetComponent<Particle>().PlayLoop();
    }

    public void ShowBuyButton(int val)
    {
        buyButton.gameObject.SetActive(true);
        buyButton.GetComponent<BuyButton>().price.text = val + "";

    }

   public void HideBuyButton()
    {
        buyButton.gameObject.SetActive(false);
    }

    public void ShowPlayButton()
    {
        playButton.gameObject.SetActive(true);
        libraryMenu.fireStart.GetComponent<Particle>().PlayLoop();
    }

    public void HidePlayButton()
    {
        playButton.gameObject.SetActive(false);
        libraryMenu.fireStart.GetComponent<Particle>().StopLoop();
    }
    
    public void ShowSecondPower()
    {
        for (int i = 0; i < filling.powers.Length; i++)
        {
            filling.powers[i].button.gameObject.SetActive(true);
            filling.powers[i].second.gameObject.SetActive(true);
        }


    }

    public void HideSecondPower()
    {
        for (int i = 0; i < filling.powers.Length; i++)
        {
            filling.powers[i].button.gameObject.SetActive(false);
            filling.powers[i].second.gameObject.SetActive(false);
        }
    }
}
