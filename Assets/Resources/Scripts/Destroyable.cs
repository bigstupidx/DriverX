using UnityEngine;
using System.Collections;

public abstract class Destroyable : MonoBehaviour {

	protected string objectName;

    protected int cost;

    public abstract void OnCollision(Transform carTransfrom);

    public int GetCost()
    {
        return cost;
    }
}
