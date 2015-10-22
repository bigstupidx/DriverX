using UnityEngine;
using System.Collections;
using System;

public class FlightTime : Task {

    public float timeRequired;
    FlightController flightControll;

    float lastTime;

    protected override void Conditions()
    {
        float fullTime = Mathf.Clamp(flightControll.GetFullTime(), 0,timeRequired);
        if (fullTime != lastTime)
        {
            MyAction(fullTime);
        }

        lastTime = fullTime;

        if (fullTime == timeRequired)
            SetJustComplete();
    }

    private void MyAction(float time)
    {
        string str = taskValue.GetHelperText(0) + " " + time.ToString("F2") + "/" + timeRequired + " " + taskValue.GetHelperText(1);
        library.taskHelper.ShowTask(str);
    }

    protected override string Description()
    {
        return taskValue.GetFullText(0) + " " + timeRequired + " " + taskValue.GetFullText(1);
    }

    // Use this for initialization
    new void Start () {
        base.Start();
        flightControll = library.car.GetComponent<FlightController>();
	}

    new void Update()
    {
        base.Update();
    }
	
}
