using UnityEngine;
using System.Collections;
using System;

public class AddParametresBoosterMenuElement : BoosterMenuElement {


    static int BoosterNum = 0;

    // Use this for initialization
    public new void Start () {
        boosterNum = BoosterNum;

        base.Start();
	}

    public static bool IsActive()
    {
        return BoosterMenuElement.IsActive(BoosterNum);
    }
    



}
