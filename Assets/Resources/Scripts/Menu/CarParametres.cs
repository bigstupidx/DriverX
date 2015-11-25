using UnityEngine;
using System.Collections;

public class CarParametres {

    string name;
    int numCar;

    int[] param = new int[3];

	public CarParametres (int numCar, string name, int[] param) {
        this.name = name;
        this.numCar = numCar;
        this.param = param;
	}
	
    public string GetName()
    {
        return name;
    }

    public int GetNumCar()
    {
        return numCar;
    }

    public int GetParam(int num)
    {
        return param[num - 1];
    }

}
