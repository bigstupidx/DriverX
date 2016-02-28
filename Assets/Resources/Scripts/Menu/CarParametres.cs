using UnityEngine;
using System.Collections;

public class CarParametres {

    string name;
    int numCar;

    int[] param = new int[3];
    int[] secondParam = new int[3];

    int cost;

    int[] upgradeCost = new int[3];

    int level;
    int minSpeed;
    bool isBonus;

	public CarParametres (int numCar, string name, int[] param, int cost, int level, int minSpeed, bool isBonus) {
        this.name = name;
        this.numCar = numCar;
        this.param = param;
        this.cost = cost;
        this.level = level;
        this.minSpeed = minSpeed;
        this.isBonus = isBonus;

        upgradeCost[0] = cost/2;
        upgradeCost[1] = cost / 2 * 3;
        upgradeCost[2] = cost / 2 * 6;

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

    public int GetUpgradeCost(int numParam)
    {
        return upgradeCost[numParam-1];
    }

    public int GetMinSpeed()
    {
        return minSpeed;
    }

    public int GetLevelCar()
    {
        return level;
    }

    public bool IsBonus()
    {
        return isBonus;
    }
}
