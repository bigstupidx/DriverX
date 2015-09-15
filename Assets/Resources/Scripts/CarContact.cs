using UnityEngine;
using System.Collections;

public class CarContact : MonoBehaviour {

    Library library;

	void Start () {
        // transform.GetComponent<Collider>().isTrigger = true;
        library = GameObject.Find("Global").GetComponent<Library>();
    }

    // Update is called once per frame
    void Update () {
	
            

	}
    

    void OnTriggerEnter(Collider col)
    {
 
        Destroyable destoyable = col.gameObject.GetComponent<Destroyable>();

        if (destoyable != null)
        {
            destoyable.OnCollision(col.transform);
        }

        library.score.AddScoreForDestroy(destoyable);

        CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(3, 3, 0.1f, 2f);
     //   c.PositionInfluence = new Vector3(1,1,1);
       // c.PositionInfluence = new Vector3(1, 1, 1);
    }
}
