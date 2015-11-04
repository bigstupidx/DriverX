using UnityEngine;
using System.Collections;
using System;

public class Barrel : Destroyable {

    Rigidbody rb;
    GameObject sparksPrefab;
    // Use this for initialization
    new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();

        sparksPrefab = Resources.Load("Prefabs/Particles/MetalSpark") as GameObject;

    }

    new void Update()
    {
        base.Update();
    }

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position - carTransform.position).normalized;//carTransform.GetComponent<CarContact>().GetDirection();
        float coef = 300;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef /6f, 0, dir.x * coef/6f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());

        GameObject particle = Instantiate(sparksPrefab);
        particle.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        particle.transform.rotation = Quaternion.LookRotation(library.car.GetComponent<CarContact>().GetDirection());
        particle.GetComponent<ParticleSystem>().Play();

    }

    IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }

  
}