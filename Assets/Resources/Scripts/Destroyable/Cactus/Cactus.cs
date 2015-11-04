﻿using UnityEngine;
using System.Collections;

public class Cactus : Destroyable {

    public GameObject particlePrefab;

    public override void OnCollision(Transform carTransfrom)
    {
        GameObject particle = Instantiate(particlePrefab);

        particle.transform.position = new Vector3(transform.position.x,transform.position.y+3,transform.position.z);
        particle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }

    protected override void LockObject()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    protected override void UnlockObject()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();
        
        if(particlePrefab == null)
        {
            particlePrefab = Resources.Load("Prefabs/Particles/CactusContact") as GameObject;
        }


    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
