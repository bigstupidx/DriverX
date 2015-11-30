using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Power : MonoBehaviour {

    public Image main;
    public Image second;
    public Button button;

    LibraryMenu libraryMenu;


    int valMain = 1;
    int valSecond = 0;

    Sprite[] mainSprites = new Sprite[6];
    Sprite[] secondSprites = new Sprite[4];
	// Use this for initialization
	void Start () {

        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        for(int i = 0; i < 6; i++)
            mainSprites[i] = Resources.Load<Sprite>("Images/GUI/Menu/car_powers/car_pow_"+(i+1));

        for (int i = 0; i < 4; i++)
            secondSprites[i] = Resources.Load<Sprite>("Images/GUI/Menu/car_updates/car_update_" + i);

        button.onClick.AddListener(
           delegate
           {
               AddPower();
           }
        );

    }

    public void AddPower()
    {
        libraryMenu.preferencesSaver.CarUpgrade(libraryMenu.carChanger.GetCurrentCarParametres().GetNumCar(), int.Parse(transform.parent.name));

        valSecond++;
        UpdateVisualize();

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void SetPower(int valMain, int valSecond)
    {
        this.valMain = valMain;
        this.valSecond = valSecond;

        UpdateVisualize();
    }

    void UpdateVisualize()
    {
        main.sprite = mainSprites[valMain-1];
        second.sprite = secondSprites[valSecond];

        if (valSecond >= 3)
            HideButton();
        else
            ShowButton();
    }

    public void HideButton()
    {
        button.gameObject.SetActive(false);
    }

    public void ShowButton()
    {
        button.gameObject.SetActive(true);
    }

}
