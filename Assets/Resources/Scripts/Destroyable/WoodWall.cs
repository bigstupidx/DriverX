using UnityEngine;
using System.Collections;

public class WoodWall : Destroyable
{
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
    new void Start()
    {
        base.Start();

    }

    new void Update()
    {
        base.Update();
    }
}
