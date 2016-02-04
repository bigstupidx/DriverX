using UnityEngine;
using System.Collections;

public class SandExlosion : MonoBehaviour {

    public GameObject destroyable;
    public Particle explosion;

    private Particle round;
    Library library;

	// Use this for initialization
	void Start () {
        round = GetComponent<Particle>();
        library = GameObject.FindObjectOfType<Library>();
	}
	
	

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Explosion());
        // round.StopLoop();


        library.secondCamera.SetActive(true);
        Destroy(round.GetParticle().gameObject);
        Destroy(GetComponent<Collider>());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.3f);
        destroyable.SetActive(false);
        explosion.GetParticle().Play();

        StartCoroutine(HideCamera());

    }

    IEnumerator HideCamera()
    {
        yield return new WaitForSeconds(2.5f);
        library.secondCamera.SetActive(false);
        Destroy(round.gameObject);

    }
}
