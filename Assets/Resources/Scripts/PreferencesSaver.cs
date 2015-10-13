using UnityEngine;
using System.Collections;

public class PreferencesSaver : MonoBehaviour {

    public void SaveTaskComplete(int level, string taskName)
    {
        PlayerPrefs.SetString("Level_" + level + "/" + taskName + "/complete", "true");
        PlayerPrefs.Save();
    }

    public bool TaskIsComplete(int level, string taskName)
    {
        string val = PlayerPrefs.GetString("Level_" + level + "/" + taskName + "/complete", "false");

        return bool.Parse(val);
    }
}
