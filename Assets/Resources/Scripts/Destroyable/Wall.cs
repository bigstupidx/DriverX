using UnityEngine;
using System.Collections;
using System;

public class Wall : Destroyable {

    public GameObject particlePrafab;


    protected override void OnCollision(Transform carTransfrom)
    {/*
        GameObject particle = Instantiate(particlePrafab);

        particle.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        particle.GetComponent<ParticleSystem>().Play();
       */ Destroy(gameObject);
    }

  

    // Use this for initialization
    new void Start () {
        base.Start();

        if (particlePrafab == null)
        {
            particlePrafab = Resources.Load("Prefabs/Particles/WallContactStone") as GameObject;
        }


    }

    // Update is called once per frame
    new void Update () {
        base.Update();
	}
}
