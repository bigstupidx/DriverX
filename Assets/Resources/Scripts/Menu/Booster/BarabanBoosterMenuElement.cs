using UnityEngine;
using System.Collections;

public class BarabanBoosterMenuElement : BoosterMenuElement
{
    static int BoosterNum = 2;

    // Use this for initialization
    public new void Start()
    {
        boosterNum = BoosterNum;

        base.Start();
    }

    public static bool IsActive()
    {
        return BoosterMenuElement.IsActive(BoosterNum);
    }
}

