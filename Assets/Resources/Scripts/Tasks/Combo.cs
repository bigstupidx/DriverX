using UnityEngine;
using System.Collections;

public class Combo : Task {

    public int points;

	// Use this for initialization
	new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override string Description()
    {
        return taskValue.GetFullText(0)+" "+points+" "+taskValue.GetFullText(1);
    }

    protected override void Conditions()
    {
        if(library.score.GetLastCombo() >= points)
            SetJustComplete();
  
    }
}
