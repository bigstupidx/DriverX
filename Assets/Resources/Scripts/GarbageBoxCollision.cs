using UnityEngine;
using System.Collections;
using System;

public class GarbageBoxCollision : DestroyableCollision {

    Rigidbody rb;
    GameObject car;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        car = GameObject.Find("Car");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = car.GetComponent<Move>().GetDirection();
        float coef = 40000;
        rb.AddForce(dir.x * coef, coef, dir.z* coef, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef*1.5f, 0, dir.x * coef*1.5f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());
        
    }

    IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
       
    }

}
