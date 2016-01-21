using UnityEngine;
using System.Collections;

public abstract class Destroyable : MonoBehaviour {

	protected string objectName;

    protected bool isLock;

    bool isUsed;

    void OnTriggerEnter(Collider collider)
    {
       

        if (collider.GetComponent<MainCollider>() != null)
        {
            library.car.GetComponent<CarContact>().OnTriggerEnter1(GetComponent<Collider>());

        }

    }
    
    public void OnCollisionObject(Transform carTransfrom)
    {
        if(!isUsed)
        OnCollision(carTransfrom);

        isUsed = true;
    }

    protected abstract void OnCollision(Transform carTransfrom);

    protected Library library;

    Shader shader1;
    Material material;

    DestroyableInfo destroyableInfo;

    

    protected void Start()
    {
        library = GameObject.FindObjectOfType<Library>();

        destroyableInfo = library.levelInfo.GetDestroyableInfo(this.GetType().Name);

        if(destroyableInfo == null)
        destroyableInfo = library.levelInfo.GetDestroyableInfo("Light");
    }

 

    public int GetCost()
    {
        return destroyableInfo.GetCost();
    }

    public int GetRewardEnergy()
    {
        return destroyableInfo.GetRewardEnergy();
    }


    protected IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }


}
