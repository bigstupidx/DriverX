using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Power : MonoBehaviour {

    public Image main;
    public Image second;
    public Button button;

    public Text cost;
    LibraryMenu libraryMenu;


    int valMain = 1;
    int valSecond = 0;

    public Sprite[] mainSprites = new Sprite[6];
    public Sprite[] secondSprites = new Sprite[4];

    int type;
	// Use this for initialization
	void Start () {

        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        type = int.Parse(transform.parent.name);

        //   for(int i = 0; i < 6; i++)
        //        mainSprites[i] = Resources.Load<Sprite>("Images/GUI/Menu/car_powers/car_pow_"+(i+1));

        //     for (int i = 0; i < 4; i++)
        //         secondSprites[i] = Resources.Load<Sprite>("Images/GUI/Menu/car_updates/car_update_" + i);

        button.onClick.AddListener(
           delegate
           {
               Button buttonOk = libraryMenu.windowConfirmation.button1;
               CarParametres carParametres = libraryMenu.carChanger.GetCurrentCarParametres();
               string tempStr = "";


               switch (type)
               {
                   case 1: tempStr = "увеличения скорости авто"; break;
                   case 2: tempStr = "увеличения объёма нитро"; break;
                   case 3: tempStr = "улучшения управляемости"; break;

               }

               int upgradeCost = carParametres.GetUpgradeCost(valSecond + 1);


               buttonOk.onClick.AddListener(
                   delegate
                   {
                       libraryMenu.windowConfirmation.Hide();

                       if (upgradeCost < Bank.GetMoney())
                       {
                           Bank.MinusMoney(upgradeCost);
                           AddPower();
                       }
                       else
                       {
                           libraryMenu.windowWarning.Show("У вас не достаточно средств для " + tempStr);
                       }
                   }
               );


               libraryMenu.windowConfirmation.Show("Стоимость " + tempStr + " составляет " + upgradeCost + "%. Произвести улучшение?");
           }
        );

    }

    public void AddPower()
    {
        PreferencesSaver.CarUpgrade(libraryMenu.carChanger.GetCurrentCarParametres().GetNumCar(), type);

        valSecond++;
        UpdateVisualize();

    }

    // Update is called once per frame
    void Update () {
        UpdateText();
        
    }

    void UpdateText()
    {
        string costText = libraryMenu.carChanger.GetCurrentCarParametres().GetUpgradeCost(valSecond + 1) + "";

        if (!costText.Equals(cost.text))
            cost.text = costText;
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
