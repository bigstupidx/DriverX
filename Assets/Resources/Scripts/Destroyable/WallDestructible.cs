using UnityEngine;
using System.Collections;

public class WallDestructible : MonoBehaviour {

    bool isDestroyable;
    Library library;
    // Use this for initialization
	void Start () {
        library = GameObject.FindObjectOfType<Library>();
	}
	
	// Update is called once per frame
	void Update () {


        if (library.car.GetComponent<CarController>().IsNitro() && !isDestroyable)
        {
            isDestroyable = true;
            foreach(Transform tr1  in transform)
            {
                foreach (Transform tr in tr1)
                {
                    Collider collider = tr.GetComponent<Collider>();
                    if (collider != null)
                        collider.isTrigger = true;

                }
            }
        }
        
        if(!library.car.GetComponent<CarController>().IsNitro() && isDestroyable)
        {
            isDestroyable = false;
            foreach (Transform tr1 in transform)
            {
                foreach (Transform tr in tr1)
                {
                    Collider collider = tr.GetComponent<Collider>();

                    if (collider != null)
                        collider.isTrigger = false;
                }
            }
        }

	}
}
