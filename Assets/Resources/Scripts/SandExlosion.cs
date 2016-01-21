using UnityEngine;
using System.Collections;

public class SandExlosion : MonoBehaviour {

    public GameObject destroyable;
    public Particle explosion;

    private Particle round;

	// Use this for initialization
	void Start () {
        round = GetComponent<Particle>();
	}
	
	

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Explosion());
        // round.StopLoop();



        Destroy(round.GetParticle().gameObject);
        Destroy(GetComponent<Collider>());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.3f);
        destroyable.SetActive(false);
        explosion.GetParticle().Play();
        Destroy(round.gameObject);


    }
}
