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
        destroyable.SetActive(false);
        round.StopLoop();
        explosion.GetParticle().Play();
    }
}
