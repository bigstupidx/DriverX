﻿using UnityEngine;
using System.Collections;


public class FlightController : MonoBehaviour
{
    Library library;
    CarContact carContact;

    float fullTime;

    float firstTimer;
    float secondTimer;
    float threshold = 0.3f;
    float fallThreshold = 1;

    float fallTimer;

    bool isCoef;

    int mnozitel = 7;

    bool wasFlight;

    public GameObject fallPrefab;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
        carContact = GetComponent<CarContact>();

        if (fallPrefab == null)
        {
            fallPrefab = Resources.Load("Prefabs/Particles/FallComples") as GameObject;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(carContact.IsFlight())
        {
            if(firstTimer < threshold)
                firstTimer += Time.deltaTime;
            else
            {
                if (!isCoef)
                {
                    library.score.AddCoef();
                    isCoef = true;
                    secondTimer += firstTimer;
                    fullTime += firstTimer;

                    fallTimer += firstTimer;
                }

                fullTime += Time.deltaTime;

                secondTimer += Time.deltaTime;

                float preVal = secondTimer * mnozitel;

                int val = (int) Mathf.Floor(preVal);

                secondTimer = preVal - val;

                library.score.AddScore(val);

                fallTimer += Time.deltaTime;

            }

            wasFlight = true;

        }
        else
        {
            if (wasFlight && carContact.IsOneContactWheel())
            {
                if(fallTimer >= fallThreshold)
                {
                    GameObject particle = Instantiate(fallPrefab);
                    particle.transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
                    particle.GetComponent<ParticleSystem>().Play();
                }
                fallTimer = 0;
                wasFlight = false;
            }

            secondTimer = 0;
            firstTimer = 0;

            isCoef = false;
        }


    }

    public float GetFullTime()
    {
        return fullTime;
    }

}
