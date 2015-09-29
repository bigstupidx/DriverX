using UnityEngine;
using System.Collections;
using System;

public class GarbageBox : Destroyable {

    Rigidbody rb;
    // Use this for initialization
    new void Start () {
        base.Start();

        rb = GetComponent<Rigidbody>();

    //    string name = this.GetType().Name;
  //      cost = 300;
  //      energy = 25;
//        minEnergy = 30;
	}

    new void Update()
    {
        base.Update();
    }

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position-carTransform.position).normalized;//carTransform.GetComponent<CarContact>().GetDirection();
        float coef = 800;
        rb.AddForce(dir.x * coef *3f, coef, dir.z* coef*3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef*1.5f, 0, dir.x * coef*1.5f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());
        
    }

    IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
       
    }

    protected override void LockObject()
    {
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    protected override void UnlockObject()
    {
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
