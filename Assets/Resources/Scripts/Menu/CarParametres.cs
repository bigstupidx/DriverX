using UnityEngine;
using System.Collections;

public class CarParametres {

    string name;
    int numCar;

    int[] param = new int[3];
    int[] secondParam = new int[3];

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

    public int GetSecondParam(int num)
    {
        return secondParam[num - 1];
    }

    public void SetSecondParams(int[] secondParam)
    {
        this.secondParam = secondParam;
    }

}
