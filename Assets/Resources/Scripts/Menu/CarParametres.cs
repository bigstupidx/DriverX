using UnityEngine;
using System.Collections;

public class CarParametres {

    string name;
    int numCar;

    int[] param = new int[3];
    int[] secondParam = new int[3];

    int cost;

    int[,] upgradeCost = new int[3,3];

	public CarParametres (int numCar, string name, int[] param, int cost, int[,] upgradeCost) {
        this.name = name;
        this.numCar = numCar;
        this.param = param;
        this.cost = cost;
        this.upgradeCost = upgradeCost;
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

    public int GetCost()
    {
        return cost;
    }

    public int GetUpgradeCost(int numParam, int numLevel)
    {
        return upgradeCost[numParam-1, numLevel-1];
    }
}
