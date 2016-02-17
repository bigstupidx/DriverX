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
        //Debug.Log(StaticValues.NumCar);
        CarParametres carParametres = CarsInfo.GetCarInfo(StaticValues.NumCar);



        if (library.car != null)
            Destroy(library.car);

        GameObject GO;
        if (carParametres == null)
            GO = Instantiate(Resources.Load("Prefabs/Cars/MK2")) as GameObject;
        else
            GO = Instantiate(Resources.Load("Prefabs/Cars/" + carParametres.GetName())) as GameObject;

        library.car = GO;
    }
}
