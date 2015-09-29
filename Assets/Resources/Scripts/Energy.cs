using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    float energy;
    float maxEnergy;
    float minusCoef = 1.3f;


    void Start () {
        maxEnergy = 100;
	}
	
    void Update()
    {
        energy = Mathf.Clamp(energy - Time.deltaTime* minusCoef* (1+energy/maxEnergy*8), 0 ,maxEnergy);
    }

	public void AddEnergy(Destroyable destroyable)
    {
        energy = Mathf.Clamp(energy + destroyable.GetRewardEnergy(), 0,maxEnergy);
    }

    public float GetEnergy()
    {
        return energy;
    }

    public float GetMaxEnergy()
    {
        return maxEnergy;
    }
}
