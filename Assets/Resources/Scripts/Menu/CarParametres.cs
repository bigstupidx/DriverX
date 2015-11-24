using UnityEngine;
using System.Collections;

public class CarParametres {

    string name;
    int numCar;
	public CarParametres (int numCar, string name) {
        this.name = name;
        this.numCar = numCar;
	}
	
    public string GetName()
    {
        return name;
    }

    public int GetNumCar()
    {
        return numCar;
    }

}
