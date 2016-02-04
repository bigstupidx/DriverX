using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    float energy;
    float maxEnergy = 100;
    float mnozitelNitro;


    static float nitroCost;


    Library library;
    void Start () {
        library = GameObject.FindObjectOfType<Library>();
        mnozitelNitro = GetComponent<CarUserParametres>().nitro;
        // maxEnergy = 0.5f * coef +mnozitelNitro/2 ;

        if (mnozitelNitro == 1)
            nitroCost = maxEnergy;
        else
            nitroCost =  maxEnergy*maxEnergy/(maxEnergy*0.5f  + mnozitelNitro*maxEnergy/2f);

    }

    void Update()
    {
        //energy = Mathf.Clamp(energy - Time.deltaTime* minusCoef* (1+energy/maxEnergy*8), 0 ,maxEnergy);
       
    }

	public void AddEnergy(Destroyable destroyable)
    {
        energy = Mathf.Clamp(energy + destroyable.GetRewardEnergy(), 0,maxEnergy);
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
