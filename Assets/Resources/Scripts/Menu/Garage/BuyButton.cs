using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BuyButton : MenuButton {

	public Text price;
  

    protected override void OnClick()
    {
        CarParametres carParametres = libraryMenu.carChanger.GetCurrentCarParametres();

        if (carParametres.GetCost() > Bank.GetMoney())
        {
            libraryMenu.windowWarning.Show("У вас не достаточно средств для покупки " + carParametres.GetName());
        }
        else
        {
            Button buttonOk = libraryMenu.windowConfirmation.button1;
            buttonOk.onClick.AddListener(
              delegate
              {
                  libraryMenu.windowConfirmation.Hide();

                  Bank.MinusMoney(carParametres.GetCost());
                  PreferencesSaver.OpenCar(carParametres.GetNumCar());

                  libraryMenu.carChanger.ShowCar();
              }  
          );
            libraryMenu.windowConfirmation.Show("Вы уверены, что хотите купить "+carParametres.GetName()+" за "+carParametres.GetCost()+"%");
            
        }

        }

    public void SetPrice(int val)
    {
        price.text = "^ " + val + "";
    }
}
