using UnityEngine;
using System.Collections;

public class Filling : MonoBehaviour {

    public Power enginePower;
    public Power nitroPower;
    public Power suspensionPower;


    public void UpdateAllPower(int engineMain, int nitroMain, int suspensionMain, int engineSecond, int nitroSecond, int suspensionSecond)
    {
        enginePower.SetPower(engineMain, engineSecond);
        nitroPower.SetPower(nitroMain, nitroSecond);
        suspensionPower.SetPower(suspensionMain, suspensionSecond);
    }
}
