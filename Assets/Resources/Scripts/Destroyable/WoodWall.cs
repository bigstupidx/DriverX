using UnityEngine;
using System.Collections;

public class WoodWall : Destroyable
{
    protected override void OnCollision(Transform carTransfrom)
    {
        Destroy(gameObject);
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
