using UnityEngine;
using System.Collections;
using System;

public class BrokenWheel : Destroyable {
    Rigidbody rb;
    // Use this for initialization
    new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();


     
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position - carTransform.position).normalized;
        float coef = 130 * library.car.GetComponent<CarController>().CurrentSpeed / library.car.GetComponent<CarController>().nMaxSpeed;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef/6f, 0, dir.x*coef/6f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());

    }

   

  
}
