using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{

    public GameObject particle;

    void Start()
    {
        GameObject GO = null;
        if (particle != null)
        {
            GO = Instantiate(particle) as GameObject;
            GO.transform.localPosition = particle.transform.localPosition;
        }
    }
}