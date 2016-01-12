using UnityEngine;
using System.Collections;
using System;

public class GlobalMainBonusUpdate : MonoBehaviour {

    DateTime lastDateTime;

	// Use this for initialization
	void Start () {
        lastDateTime = PreferencesSaver.GetMainBonusTime();
	}
	
	// Update is called once per frame
	void Update () {

        DateTime nowTime = System.DateTime.Now;

        if(nowTime.Subtract(lastDateTime).TotalSeconds > 1800)
        {
            if (MainBonus.count < MainBonus.MaxValue)
            {
                MainBonus.count++;

                lastDateTime = nowTime;

                PreferencesSaver.SaveMainBonusTime(lastDateTime);
            }
        }
        
	}
}
