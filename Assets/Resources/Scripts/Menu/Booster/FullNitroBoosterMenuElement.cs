using UnityEngine;
using System.Collections;

public class FullNitroBoosterMenuElement : BoosterMenuElement
{


    static int BoosterNum = 1;

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
