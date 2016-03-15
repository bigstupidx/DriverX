using UnityEngine;
using System.Collections;

public class CarCreator : MonoBehaviour {

    Library library;
	// Use this for initialization
	void Start () {
        library = GameObject.FindObjectOfType<Library>();

        UpdateCar();

    }
	
    public void UpdateCar()
    {
        CarParametres carParametres = CarsInfo.GetCarInfo(StaticValues.NumCar);

        if (library.car != null)
            Destroy(library.car);

        GameObject GO;
        GameObject carPref;
        if (carParametres == null)
            carPref = Resources.Load("Prefabs/Cars/HemiFox") as GameObject;
        else
            carPref = Resources.Load("Prefabs/Cars/" + carParametres.GetName()) as GameObject;


        carPref.transform.position = new Vector3(0, 1000, 0);

        GO = Instantiate(carPref);

        library.car = GO;
    }
}
