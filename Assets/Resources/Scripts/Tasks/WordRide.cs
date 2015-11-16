using UnityEngine;
using System.Collections;
using System;

public class WordRide : Task {

    bool[] letterArray = new bool[4];

	new void Start () {
        base.Start();

        if (IsComplete())
        {
            Destroy(library.level.transform.FindChild("Elements").FindChild("WordRide").gameObject);
        }
    }
	
	new void Update () {
        base.Update();
	}
    
    public void CheckLetter(int numLetter)
    {
        letterArray[numLetter - 1] = true;

        library.wordRideCanvas.ShowLetter(numLetter-1);
    }

    protected override string Description()
    {
        return taskValue.GetFullText(0);
    }

    protected override void Conditions()
    {
        bool temp = true;
        for(int i =0; i < letterArray.Length; i++)
            temp = temp & letterArray[i];
        
        if(temp)
            SetJustComplete();
        
    }
}
