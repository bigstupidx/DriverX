using UnityEngine;
using System.Collections;

public class DestroyableInfo {

	private int cost;
    private int minEnergy;
    private int rewardEnergy;

    public DestroyableInfo(int cost, int minEnergy, int rewardEnergy)
    {
        this.cost = cost;
        this.minEnergy = minEnergy;
        this.rewardEnergy = rewardEnergy;
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetMinEnergy()
    {
        return minEnergy;
    }

    public int GetRewardEnergy()
    {
        return rewardEnergy;
    }
}
