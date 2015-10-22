using UnityEngine;
using System.Collections;
using System;

public class Points : Task {

    public int maxPoints;

    protected override void Conditions()
    {
        throw new NotImplementedException();
    }

    protected override string Description()
    {
        return taskValue.GetFullText(0) + " " + maxPoints + " " + taskValue.GetFullText(1);
    }

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Start();
	}
}
