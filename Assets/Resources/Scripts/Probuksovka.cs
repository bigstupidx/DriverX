using UnityEngine;
using System.Collections;


public class Probuksovka : MonoBehaviour
{

    Library library;
    public GameObject probuksovkaParticlePrefab;
    ParticleSystem probuksovkaParticle;
    // ParticleSystem rideEffect;
    bool isProbuksovka;

    Vector3 dir = new Vector3();
    Vector3 lastPos = new Vector3();

    CarController carController;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();

        carController = library.car.GetComponent<CarController>();
        if (probuksovkaParticlePrefab == null)
            probuksovkaParticlePrefab = Resources.Load("Prefabs/Particles/WheelOut") as GameObject;

        GameObject probuksovkaParticleGO = Instantiate(probuksovkaParticlePrefab);

        probuksovkaParticleGO.transform.SetParent(transform, false);

        probuksovkaParticle = probuksovkaParticleGO.GetComponent<ParticleSystem>();
        //    rideEffect = transform.FindChild("RideEffectWheel").GetComponent<ParticleSystem>();

        lastPos = transform.position;

    }

    void FixedUpdate()
    {
        dir = (transform.position - lastPos).normalized;
        lastPos = transform.position;
    }

    public void ProbuksovkaEmit()
    {
        if (GetComponent<WheelCollider>().isGrounded && GetComponent<WheelCollider>().motorTorque > 0 && carController.CurrentSpeed < 25)
        {
            if (probuksovkaParticle.loop == false)
            {
                probuksovkaParticle.gameObject.SetActive(false);
                probuksovkaParticle.gameObject.SetActive(true);
                probuksovkaParticle.loop = true;
            }
        }
        else
            if(probuksovkaParticle.loop == true)
                probuksovkaParticle.loop = false;
    }

    /*
    public void RideEffectEmit()
    {

        if (GetComponent<WheelCollider>().isGrounded)
        {
            Quaternion quater = Quaternion.LookRotation(dir);
            quater *= Quaternion.Euler(0, 180, 0);
            rideEffect.transform.rotation = Quaternion.Slerp(rideEffect.transform.rotation, quater, Time.deltaTime * 5);
                
            TwoColor twoColor = rideEffect.GetComponent<TwoColor>();
            Color color = rideEffect.startColor;

            if (twoColor != null)
            {

                if (Random.Range(1, 3) == 1)
                    color = twoColor.color1;
                else
                    color = twoColor.color2;
            }

            color.a = color.a * library.car.GetComponent<CarController>().CurrentSpeed / library.car.GetComponent<CarController>().MaxSpeed;
            rideEffect.startColor = color;
            rideEffect.Emit(1);

            //  if(!rideEffect.IsAlive())
            //{
                //  rideEffect.Play();
            //}

        }
    }*/
}

