using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{

    public class Probuksovka : MonoBehaviour
    {

        Library library;
        GameObject probuksovkaParticle;
        bool isProbuksovka;

        // Use this for initialization
        void Start()
        {
            library = GameObject.FindObjectOfType<Library>();
            probuksovkaParticle = transform.GetChild(0).gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody carRigid = library.car.GetComponent<Rigidbody>();
            if (library.car.GetComponent<CarController>().CurrentSpeed < 12 && GetComponent<WheelCollider>().isGrounded && GetComponent<WheelCollider>().motorTorque > 0)
            {
                if (!isProbuksovka)
                {
                    probuksovkaParticle.SetActive(false);
                    probuksovkaParticle.SetActive(true);
                    probuksovkaParticle.GetComponent<ParticleSystem>().loop = true;
                    probuksovkaParticle.transform.GetChild(0).GetComponent<ParticleSystem>().loop = true;
                    isProbuksovka = true;
                }
                //probuksovkaParticle.SetActive(true);
            }
            else
            {
                if (isProbuksovka)
                {
                    probuksovkaParticle.GetComponent<ParticleSystem>().loop = false;
                    probuksovkaParticle.transform.GetChild(0).GetComponent<ParticleSystem>().loop = false;
                    isProbuksovka = false;
                }
                //probuksovkaParticle.SetActive(false);
            }

        }
    }
}
