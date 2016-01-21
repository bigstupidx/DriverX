using UnityEngine;
using System.Collections;

public class YellowBox : Destroyable {
    Rigidbody rb;
    // Use this for initialization
    new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();

    
    }


    protected override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position - carTransform.position).normalized;//carTransform.GetComponent<CarContact>().GetDirection();
        float coef = 800;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef * 1.5f, 0, dir.x * coef * 1.5f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());

    }

   
  
}
