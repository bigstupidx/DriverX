using UnityEngine;
using System.Collections;

public class Kanistra : MonoBehaviour {

    // Use this for initialization
    Library library;

    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<MainCollider>() != null)
        {
            library.car.GetComponent<CarContact>().OnTriggerEnter1(GetComponent<Collider>());

        }

    }
}
