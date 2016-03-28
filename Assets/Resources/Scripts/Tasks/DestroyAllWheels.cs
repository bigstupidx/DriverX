using UnityEngine;
using System.Collections.Generic;
using System;

public class DestroyAllWheels : Task {


    // Use this for initialization
    new void Start ()
    {
        base.Start();
	}
	
    new void Update()
    {
        base.Update();


    }

    protected override string Description()
    {
        return taskValue.GetFullText(0);
    }

    protected override void Conditions()
    {
        int count = library.car.GetComponent<CarContact>().GetDestroyableCount("BrokenWheel");

        if (count == 4)
            SetJustComplete();
    }

}
