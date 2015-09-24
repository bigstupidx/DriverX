using UnityEngine;
using System.Collections;
using System;

public class GarbageBox : Destroyable {

    Rigidbody rb;
    GameObject car;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        car = GameObject.Find("Car");


        cost = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = car.GetComponent<CarContact>().GetDirection();
        float coef = 40000;
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

}
