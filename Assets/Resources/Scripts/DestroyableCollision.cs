using UnityEngine;
using System.Collections;

public abstract class DestroyableCollision : MonoBehaviour {

	protected string objectName;

    public abstract void OnCollision(Transform carTransfrom);
}
