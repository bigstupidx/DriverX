using UnityEngine;
using System.Collections;

public abstract class Destroyable : MonoBehaviour {

	protected string objectName;

    protected bool isLock;

    public abstract void OnCollision(Transform carTransfrom);

    public Library library;

    Shader shader1;
    Material material;

    DestroyableInfo destroyableInfo;

    protected void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
       // Debug.Log(library.levelInfo);
        destroyableInfo = library.levelInfo.GetDestroyableInfo("Light");
    }

    protected void Update()
    {
        /*
        if(library.energy.GetEnergy() < destroyableInfo.GetMinEnergy())
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
        }*/
    }

    public int GetCost()
    {
        return destroyableInfo.GetCost();
    }

    public int GetRewardEnergy()
    {
        return destroyableInfo.GetRewardEnergy();
    }



}
