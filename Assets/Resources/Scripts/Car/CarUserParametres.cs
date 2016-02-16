using UnityEngine;
using System.Collections;

public class CarUserParametres : MonoBehaviour {

    public static int maxVal = 9;
    [Range(1, 9)] public int speed;
    [Range(1, 9)] public int nitro;
    [Range(1, 9)] public int controllability;

    Library library;
    // Use this for initialization
    void Awake () {

        
        CarParametres carParametres = CarsInfo.GetCarInfo(StaticValues.NumCar);
        if (carParametres != null && StaticValues.NumLevel != 999)
        {

            speed = carParametres.GetParam(1) + PreferencesSaver.GetCarUpgrade(StaticValues.NumCar, 1);
            nitro = carParametres.GetParam(2) + PreferencesSaver.GetCarUpgrade(StaticValues.NumCar, 2);
            controllability = carParametres.GetParam(3) + PreferencesSaver.GetCarUpgrade(StaticValues.NumCar, 3);
        }
        controllability = Mathf.Clamp(controllability, 1, maxVal);
        nitro = Mathf.Clamp(nitro, 1, maxVal);
        speed = Mathf.Clamp(speed, 1, maxVal);


    }

    // Update is called once per frame
    void Update () {

    }
}
