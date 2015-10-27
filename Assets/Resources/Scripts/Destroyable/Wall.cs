using UnityEngine;
using System.Collections;
using System;

public class Wall : Destroyable {
    public override void OnCollision(Transform carTransfrom)
    {
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
    new void Start () {
        base.Start();

    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}
}
