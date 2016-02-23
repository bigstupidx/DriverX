using UnityEngine;
using System.Collections;
using System;

public class PreferencesSaver : MonoBehaviour {

    public static string pass = "HeyKey";

    public static void SaveTaskComplete(int level, string taskName)
    {
        SavePref("Level_" + level + "/" + taskName + "/complete", "true");
    }

    public static bool TaskIsComplete(int level, string taskName)
    {
        string val = GetPref("Level_" + level + "/" + taskName + "/complete", "false");

        if (!val.Equals("true"))
            return false;
        else
            return true;
    }

    public static void SaveTaskValue(int level, string taskName, string val)
    {
        SavePref("Level_" + level + "/" + taskName + "/value", val);
    }

    public static string GetTaskValue(int level, string taskName)
    {
        string val = GetPref("Level_" + level + "/" + taskName + "/value", "");

        return val;
    }

    public static int GetIntTaskValue(int level, string taskName)
    {
        string str = GetTaskValue(level, taskName);

        int number;
        try
        {
            number = int.Parse(str);
        }
        catch (FormatException)
        {
            number = 0;
        }

        return number;
    }


    public static void SaveCurrentCar(int num)
    {
        SavePref("CurrentCar", num+"");
    }

    public static int GetCurrentCar()
    {
        string val = GetPref("CurrentCar", 0+"");
        return int.Parse(val);
    }

    public static void OpenCar(int num)
    {
        SavePref("OpenCar/" + num, true+"");
        SaveCurrentCar(num);
    }

    public static bool CarIsOpen(int num)
    {
        bool isOpen = false;

        if (num == 0)
            return true;

        try
        {
            isOpen = bool.Parse(GetPref("OpenCar/" + num, "false"));
        }
        catch (FormatException)
        {
            isOpen = false;
        }


        return isOpen;
    }

    public static void CarUpgrade(int numCar, int numParameter)
    {
        SavePref("CarUpgrade_" + numCar+"/"+numParameter, (GetCarUpgrade(numCar,numParameter)+1)+"");
    }

    public static int GetCarUpgrade(int numCar, int numParameter)
    {
       return int.Parse(GetPref("CarUpgrade_" + numCar+"/"+numParameter, 0+""));
    }

    public static void SetMoney(int money)
    {
        SavePref("Money", money + "");
    }

    public static int GetMoney()
    {
        return int.Parse(GetPref("Money", 0 + ""));
    }

    public static void SetBarabanBooster(int val)
    {
        SavePref("BarabanBooster", val + "");
    }

    public static int GetBarabanBooster()
    {
        return int.Parse(GetPref("BarabanBooster", 0 + ""));
    }

    public static void SetGold(int gold)
    {
        SavePref("Gold", gold + "");
    }

    public static int GetGold()
    {
        return int.Parse(GetPref("Gold", 0 + ""));
    }

    public static void SetMainBonus(int col)
    {
        SavePref("MainBonus", col + "");
    }

    public static int GetMainBonus()
    {
        return int.Parse(GetPref("MainBonus", MainBonus.MaxValue + ""));
    }

    public static void SaveMainBonusTime(DateTime dateTime)
    {
        SavePref("LastTimeMainBonus", dateTime.ToString());        
    }

    public static DateTime GetMainBonusTime()
    {
        try
        {
            return System.DateTime.Parse(GetPref("LastTimeMainBonus", System.DateTime.MinValue.ToString()));
        }
        catch (FormatException)
        {
            return System.DateTime.MinValue;
        }

    }

    private static void SavePref(string key, string val)
    {
        SecurePlayerPrefs.SetString(key, val, pass);
        PlayerPrefs.Save();
    }

    private static string GetPref(string key, string defaultValue)
    {
        return SecurePlayerPrefs.GetString(key, defaultValue, pass);
    }

    

}
