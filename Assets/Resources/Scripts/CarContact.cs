using UnityEngine;
using System.Collections;

public class CarContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // transform.GetComponent<Collider>().isTrigger = true;

    }

    // Update is called once per frame
    void Update () {
	
            

	}
    

    void OnTriggerEnter(Collider col)
    {
 
        DestroyableCollision destoyableCollision = col.gameObject.GetComponent<DestroyableCollision>();

        if (destoyableCollision != null)
        {
            destoyableCollision.OnCollision(col.transform);
        }
        
        CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(3, 3, 0.1f, 2f);
     //   c.PositionInfluence = new Vector3(1,1,1);
       // c.PositionInfluence = new Vector3(1, 1, 1);
    }
}
