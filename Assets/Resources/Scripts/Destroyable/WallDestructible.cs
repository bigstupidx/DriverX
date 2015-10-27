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
	    if(library.car.GetComponent<CarController>().IsNitro() && !isDestroyable)
        {
            isDestroyable = true;
            foreach(Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.isTrigger = true;
            }
        }
        
        if(!library.car.GetComponent<CarController>().IsNitro() && isDestroyable)
        {
            isDestroyable = false;
            foreach (Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.isTrigger = false;
            }
        }

	}
}
