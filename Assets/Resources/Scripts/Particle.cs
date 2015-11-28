using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Particle : MonoBehaviour
{

    public GameObject particle;
    public bool autoStart;
    
    GameObject GO = null;
    void Start()
    {

        if (particle != null)
        {
            GO = Instantiate(particle) as GameObject;
            GO.transform.SetParent(transform, false);

            if (GO.GetComponent<RectTransform>() != null && particle.transform.GetComponent<RectTransform>() != null)
            {
                GO.GetComponent<RectTransform>().anchoredPosition = particle.GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
                GO.transform.localPosition = particle.transform.localPosition;
            }

            if (autoStart)
            {
                foreach (ParticleSystem ps in GO.GetComponentsInChildren<ParticleSystem>())
                {
                    ps.loop = true;
                    ps.playOnAwake = true;
                    GO.SetActive(false);
                    GO.SetActive(true);
                }
            }
            else
            {
                foreach (ParticleSystem ps in GO.GetComponentsInChildren<ParticleSystem>())
                {
                    ps.loop = false;
                    ps.playOnAwake = false;
                    GO.SetActive(false);
                    GO.SetActive(true);
                }
            }
        }
    }
  
    public void PlayLoop()
    {
        if (GO != null)
        {
            GO.SetActive(true);
            foreach (ParticleSystem ps in GO.GetComponentsInChildren<ParticleSystem>())
            {
                ps.playOnAwake = true;
                ps.loop = true;
                GO.SetActive(false);
                GO.SetActive(true);
            }
        }
    }

    public void StopLoop()
    {
        if (GO != null)
        {
            GO.SetActive(true);
            foreach (ParticleSystem ps in GO.GetComponentsInChildren<ParticleSystem>())
            {
                ps.playOnAwake = false;
                ps.loop = false;
                GO.SetActive(false);
            }
        }
    }
}