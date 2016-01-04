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
        TakeKanistra takeKanistra = library.level.GetComponentInChildren<TakeKanistra>();

        if (takeKanistra != null)
            takeKanistra.SetTake();

        Destroy(gameObject);


    }
}
