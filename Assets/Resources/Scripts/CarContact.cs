using UnityEngine;
using System.Collections;

public class CarContact : MonoBehaviour {

    Library library;
    Vector3 dir = new Vector3();
    Vector3 lastPos = new Vector3();


    void Start () {
        // transform.GetComponent<Collider>().isTrigger = true;
        library = GameObject.Find("Global").GetComponent<Library>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        UpdateDirection();        
	}

    private void UpdateDirection()
    {
        dir = (transform.position - lastPos).normalized;
        lastPos = transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
 
        Destroyable destoyable = col.gameObject.GetComponent<Destroyable>();

        if (destoyable != null)
        {
            destoyable.OnCollision(transform);
            library.score.AddScoreForDestroy(destoyable);
            library.energy.AddEnergy(destoyable);

            CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(3, 3, 0.1f, 2f);
        }


        //   c.PositionInfluence = new Vector3(1,1,1);
        // c.PositionInfluence = new Vector3(1, 1, 1);
    }

    public Vector3 GetDirection()
    {
        return dir;
    }

}
