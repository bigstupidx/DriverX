using UnityEngine;
using System.Collections;

public abstract class Destroyable : MonoBehaviour {

	protected string objectName;

    protected int cost;

    protected int energy;

    protected int minEnergy;

    protected bool isLock;

    public abstract void OnCollision(Transform carTransfrom);

    Library library;

    protected void Start()
    {
        library = GameObject.FindObjectOfType<Library>();    
    }

    protected void Update()
    {
        if(library.energy.GetEnergy() < minEnergy)
        {
            if (!isLock)
            {
                LockObject();
                isLock = true;
            }
        }
        else
        {
            if (isLock)
            {
                UnlockObject();
                isLock = false;
            }
        }
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public int GetMinEnergy()
    {
        return minEnergy;
    }

    abstract protected void LockObject();
    abstract protected void UnlockObject();
}
