using UnityEngine;
using System.Collections;

public class Filling : MonoBehaviour {

    public Power[] powers = new Power[3];



    public void UpdateAllPower(int engineMain, int nitroMain, int suspensionMain, int engineSecond, int nitroSecond, int suspensionSecond)
    {
        powers[0].SetPower(engineMain, engineSecond);
        powers[1].SetPower(nitroMain, nitroSecond);
        powers[2].SetPower(suspensionMain, suspensionSecond);
    }
}
