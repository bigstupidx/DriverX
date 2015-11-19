using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    float energy;
    float maxEnergy;
    float mnozitelNitro;

    float nitroCost = 1;

    Library library;
    void Start () {
        library = GameObject.FindObjectOfType<Library>();
        mnozitelNitro = GetComponent<CarUserParametres>().nitro;
        maxEnergy = 0.5f +mnozitelNitro/2;
	}
	
    void Update()
    {
        //energy = Mathf.Clamp(energy - Time.deltaTime* minusCoef* (1+energy/maxEnergy*8), 0 ,maxEnergy);
       
    }

	public void AddEnergy(Destroyable destroyable)
    {
        energy = Mathf.Clamp(energy + maxEnergy/10f, 0,maxEnergy);
    }

    public void UseEnergy()
    {
        energy = Mathf.Clamp(energy - nitroCost, 0, maxEnergy);
    }

    public bool EnergyEnough()
    {
        if (energy >= nitroCost)
            return true;
        else
            return false;
    }

    public float GetEnergy()
    {
        return energy;
    }

    public float GetMaxEnergy()
    {
        return maxEnergy;
    }

    public float GetNitroCost()
    {
        return nitroCost;
    }

    public void ToDefault()
    {
        energy = 0;
        library.energyLine.ToDefault();
    }

  
}
