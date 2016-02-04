using UnityEngine;
using System.Collections;

public class LevelInfo
{
    private int time;
    private string name;

    public LevelInfo(string name, int time)
    {
        this.name = name;
        this.time = time;
    }

    public int GetTime()
    {
        return time;
    }

    public string GetName()
    {
        return name;
    }

}

