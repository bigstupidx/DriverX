using UnityEngine;
using System.Collections;
using System;

public class PreferencesSaver : MonoBehaviour {

    public static string pass = "HeyKey";

    public void SaveTaskComplete(int level, string taskName)
    {
        SavePref("Level_" + level + "/" + taskName + "/complete", "true");
    }

    public bool TaskIsComplete(int level, string taskName)
    {
        string val = GetPref("Level_" + level + "/" + taskName + "/complete", "false");

        if (!val.Equals("true"))
            return false;
        else
            return true;
    }

    public void SaveTaskValue(int level, string taskName, string val)
    {
        SavePref("Level_" + level + "/" + taskName + "/value", val);
    }

    public string GetTaskValue(int level, string taskName)
    {
        string val = GetPref("Level_" + level + "/" + taskName + "/value", "");

        return val;
    }

    public int GetIntTaskValue(int level, string taskName)
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

    private void SavePref(string key, string val)
    {
        SecurePlayerPrefs.SetString(key, val, pass);
        PlayerPrefs.Save();
    }

    private string GetPref(string key, string defaultValue)
    {
        return SecurePlayerPrefs.GetString(key, defaultValue, pass);
    }

}
