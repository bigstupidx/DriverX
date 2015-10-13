using UnityEngine;
using System.Collections.Generic;

public class DestroyAllWheels : Task {

	// Use this for initialization
	new void Start ()
    {
        base.Start();
	}
	
    new void Update()
    {
        base.Update();

        if(!IsComplete())
        {
            int count = library.car.GetComponent<CarContact>().GetDestroyableCount("BrokenWheel");

            if (count == 4)
            SetJustComplete();
        }

    }
}
