using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullNitroBoosterButton : BoosterButton
{


    protected override void UseButtonPersonal()
    {
     //   Bank.MinusBooster2(1);
        library.energy.SetMaxEnergy();
    }


    protected override void UpdateCount()
    {
        //count.text = Bank.GetBooster2() + "";
    }


}