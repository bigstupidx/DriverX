using UnityEngine;
using System.Collections;

public class Probuksovka : MonoBehaviour {

    Library library;
    GameObject probuksovkaParticle;

    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
        probuksovkaParticle = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody carRigid = library.car.GetComponent<Rigidbody>();
            if (library.car.transform.InverseTransformDirection(carRigid.velocity).z < 15 && GetComponent<WheelCollider>().isGrounded && GetComponent<WheelCollider>().motorTorque > 0)
            {
                if(!probuksovkaParticle.activeSelf)
                    probuksovkaParticle.SetActive(true);
            }
            else
            {
                if (probuksovkaParticle.activeSelf)
                    probuksovkaParticle.SetActive(false);
            }

    }
}
