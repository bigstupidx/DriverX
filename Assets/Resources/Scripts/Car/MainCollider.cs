using UnityEngine;
using System.Collections;

public class MainCollider : MonoBehaviour
{

    Library library;
    CarContact carContact;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
        carContact = library.car.GetComponent<CarContact>();
    }
    /*
    void OnTriggerEnter(Collider col)
    {
        carContact.OnTriggerEnter1(col);
    }*/

   
}