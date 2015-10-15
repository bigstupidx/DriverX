using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    float timeLeft;
    void Start () {
        timeLeft = 90;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft = Mathf.Clamp(timeLeft - Time.deltaTime, 0, 1000);
	}

    public float GetTimeLeft()
    {
        return timeLeft;
    }


}
