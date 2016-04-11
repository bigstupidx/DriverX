using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public abstract class BoosterMenuElement : MonoBehaviour {


    protected int boosterNum;
     
    LibraryMenu libraryMenu;

    public Text description;
    public Text cost;
    public Text time;

 //   bool isActive;

    DateTime lastDateTime;
    TimeSpan subtractTime;

    bool isActive;


    // Use this for initialization
    public void Start () {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        lastDateTime = PreferencesSaver.GetBoosterActivateTime(boosterNum);
        description.text = TextStrings.GetString("booster_"+boosterNum+"_description");

        
    }




    public void BuyBoosters()
    {
        if (isActive)
        {
            libraryMenu.windowWarning.Show(TextStrings.GetString("booster_is_active"));
        }
        else
        {
            if (Bank.GetFreeBooster(boosterNum) > 0)
            {
                lastDateTime = System.DateTime.Now;
                PreferencesSaver.SetBoosterActivateTime(boosterNum, lastDateTime);
                Bank.MinusFreeBooster(boosterNum,1);
                
            }
            else
            {
                if (BoosterValues.BoosterCost[boosterNum] > Bank.GetMoney())
                {
                    libraryMenu.windowWarning.Show(TextStrings.GetString("no_money"));
                }
                else
                {
                    lastDateTime = System.DateTime.Now;
                    PreferencesSaver.SetBoosterActivateTime(boosterNum, lastDateTime);
                    Bank.MinusMoney(BoosterValues.BoosterCost[boosterNum]);
                }
            }
        }
    }

    public void Update()
    {
        DateTime nowTime = System.DateTime.Now;

        subtractTime = nowTime.Subtract(lastDateTime);


        if (subtractTime.TotalSeconds < BoosterValues.BoosterTime[boosterNum] * 60)
        {   
            UpdateTime();
            cost.text = TextStrings.GetString("is_activate");
            isActive = true;
        }
        else
        {
            string timeText = BoosterValues.BoosterTime[boosterNum] + " " + TextStrings.GetString("minutes");

            if (!time.text.Equals(timeText))
                time.text = timeText;

                if (Bank.GetFreeBooster(boosterNum) > 0)
                {
                    string textCost = TextStrings.GetString("free");
                    if(!cost.text.Equals(textCost))
                        cost.text = textCost;
                }
                else
                {
                    string textCost = "^ " + BoosterValues.BoosterCost[boosterNum];
                     if (!cost.text.Equals(textCost))
                        cost.text = textCost;
                }
            
        }

    }

    void UpdateTime()
    {
        TimeSpan ts = (new TimeSpan(0, (int)Mathf.Floor(BoosterValues.BoosterTime[boosterNum]), BoosterValues.BoosterTime[boosterNum] * 60 % 60)).Subtract(subtractTime);

        string timeTemp = ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

        if (!time.text.Equals(timeTemp))
        {
            time.text = timeTemp;
        }
    }

    public static bool IsActive(int num)
    {
        DateTime nowTime = System.DateTime.Now;
   
        TimeSpan subtractTime = nowTime.Subtract(PreferencesSaver.GetBoosterActivateTime(num));

        if (subtractTime.TotalSeconds < BoosterValues.BoosterTime[num] * 60)
            return true;
        else
            return false;
    }


    

}
