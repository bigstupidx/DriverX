using UnityEngine;
using System.Collections;

public class DestroyableInfo {

	private int cost;
    private int rewardEnergy;

    public DestroyableInfo(int cost, int rewardEnergy)
    {
        this.cost = cost;
        this.rewardEnergy = rewardEnergy;
    }

    public int GetCost()
    {
        return cost;
    }



    public int GetRewardEnergy()
    {
        return rewardEnergy;
    }
}
