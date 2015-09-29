using UnityEngine;
using System.Collections;

public abstract class Destroyable : MonoBehaviour {

	protected string objectName;

    protected bool isLock;

    public abstract void OnCollision(Transform carTransfrom);

    Library library;

    Shader shader1;
    Material material;

    DestroyableInfo destroyableInfo;

    protected void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
       // Debug.Log(library.levelInfo);
        destroyableInfo = library.levelInfo.GetDestroyableInfo(this.GetType().Name);

        shader1 = Shader.Find("Outlined/Diffuse");
        Renderer renderer = transform.GetComponent<Renderer>();
        if (renderer != null)
            material = renderer.material;
        else
            material = transform.GetComponentInChildren<Renderer>().material;

        material.SetColor("_OutlineColor", Color.green);
    }

    protected void Update()
    {
        if(library.energy.GetEnergy() < destroyableInfo.GetMinEnergy())
        {
            if (!isLock)
            {
                LockObject();
                isLock = true;
                material.SetColor("_OutlineColor", Color.red);
            }
        }
        else
        {
            if (isLock)
            {
                UnlockObject();
                isLock = false;
                material.SetColor("_OutlineColor", Color.green);
            }
        }
    }

    public int GetCost()
    {
        return destroyableInfo.GetCost();
    }

    public int GetRewardEnergy()
    {
        return destroyableInfo.GetRewardEnergy();
    }

    public int GetMinEnergy()
    {
        return destroyableInfo.GetMinEnergy();
    }

    abstract protected void LockObject();
    abstract protected void UnlockObject();
}
