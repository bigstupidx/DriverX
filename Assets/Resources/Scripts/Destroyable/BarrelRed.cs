using UnityEngine;
using System.Collections;

public class BarrelRed : Destroyable
{

    Rigidbody rb;
    public GameObject explosion;
    // Use this for initialization
    new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();
    }

    new void Update()
    {
        base.Update();
    }

    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = (transform.position - carTransform.position).normalized;//carTransform.GetComponent<CarContact>().GetDirection();
        float coef = 130;
        rb.AddForce(dir.x * coef * 3f, coef, dir.z * coef * 3f, ForceMode.Impulse);
        rb.AddTorque(dir.z * coef / 6f, 0, dir.x * coef / 6f, ForceMode.Impulse);
        Destroy(GetComponent<Collider>());
        StartCoroutine(HideTimer());

        library.car.GetComponent<CarContact>().MetalSparks(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z));

    }


    protected new IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(0.4f);

        GameObject expl = Instantiate(explosion) as GameObject;
        expl.transform.position = transform.position; 
        expl.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        
    }
}