using UnityEngine;
using System.Collections;

public class Bui : Destroyable
{

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }



    protected override void OnCollision(Transform carTransform)
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = 20;
        

        Vector3 dir = (transform.position - carTransform.position).normalized;//carTransform.GetComponent<CarContact>().GetDirection();
        float coef = 130;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef / 6f, 0, dir.x * coef / 6f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());

        library.car.GetComponent<CarContact>().MetalSparks(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z));

    }

}
