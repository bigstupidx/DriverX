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

    protected override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position - carTransform.position).normalized;
        float coef = 130;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef / 6f, 0, dir.x * coef / 6f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());
        library.car.GetComponent<CarContact>().MetalSparks(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z));

    }

 

}
