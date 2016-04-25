using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GiftGO : MonoBehaviour {

    public Text description;
    public Text numDay;
    public Image image;
    public Image panel;

    public Sprite[] imageSprites = new Sprite[5];
    public Sprite[] imageSprites1 = new Sprite[5];


    public Sprite[] steelSprites = new Sprite[2];
    public Sprite[] goldSprites = new Sprite[2];


    Gift gift;

    public void SetGift(Gift gift, int numDay)
    {
        this.gift = gift;

        if (gift.type.Equals(Gift.GiftType.Box))
            SetDescription();
        else
            SetDescription(gift.val1);

        SetNumDay(numDay);

        SetImage();

        SetMain();
    }

    void SetDescription(int val1)
    {
        int padej = Padej.GetPadej(val1);
        
        switch(gift.type)
        {
            case Gift.GiftType.Money: description.text = "+" + val1 + " " + TextStrings.GetString("valuta");  break;
            case Gift.GiftType.Booster1: description.text = "+" + val1 + " " + TextStrings.GetString("tuning_set_"+padej); break;
            case Gift.GiftType.Booster2: description.text = "+" + val1 + " " + TextStrings.GetString("full_tank_" + padej);  break;
            case Gift.GiftType.Booster3: description.text = "+" + val1 + " " + TextStrings.GetString("additional_rates_" + padej); break;
            case Gift.GiftType.Bonus: description.text = "+" + val1 + " " + TextStrings.GetString("bonus_" + padej); break;
        }
        
    }

    void SetDescription()
    {
        description.text = TextStrings.GetString("secret_box");
    }


    void SetNumDay(int numDay)
    {
        this.numDay.text = numDay + " " + TextStrings.GetString("day");
    }
    
    void SetImage()
    {
        switch (gift.type)
        {
            case Gift.GiftType.Money: image.sprite = imageSprites[0]; break;
            case Gift.GiftType.Booster1: image.sprite = imageSprites[1]; break;
            case Gift.GiftType.Booster2: image.sprite = imageSprites[2]; break;
            case Gift.GiftType.Booster3: image.sprite = imageSprites[3]; break;
            case Gift.GiftType.Bonus: image.sprite = imageSprites[4]; break;
        }
    }

    void SetMain()
    {
        if (gift.isMain)
            panel.sprite = goldSprites[0];

    }
  
    public void SetToday()
    {
        if (gift.isMain)
            panel.sprite = goldSprites[1];
        else
            panel.sprite = steelSprites[1];


        for(int i = 0; i <imageSprites1.Length; i++)
        {
            if (image.sprite.Equals(imageSprites[i]))
            {
                image.sprite = imageSprites1[i];
                break;
            }

        }

    }

}
