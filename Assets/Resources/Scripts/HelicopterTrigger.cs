using UnityEngine;
using System.Collections;

public class HelicopterTrigger : MonoBehaviour
{

    // Use this for initialization

    Library library;

    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        JumpHelicopter jh = library.level.GetComponentInChildren<JumpHelicopter>();

        if (jh != null)
            jh.SetTake();

        Destroy(gameObject);        

    }
}
