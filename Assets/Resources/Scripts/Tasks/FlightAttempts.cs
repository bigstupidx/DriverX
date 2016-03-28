using UnityEngine;
using System.Collections;
using System;

public class FlightAttempts : Task
{

    public int attempts;
    int lastAttempts;
    FlightController flightControll;

    float lastTime;

    protected override void Conditions()
    {
        int currentAttempts = flightControll.GetJumpCount();

        if (currentAttempts != lastAttempts)
        {
            MyAction(currentAttempts);
        }

        lastAttempts = currentAttempts;

        if (attempts == currentAttempts)
            SetJustComplete();
    }

    private void MyAction(int currentAttempts)
    {
        string str = taskValue.GetHelperText(0) + " " + currentAttempts + "/" + attempts + " " + taskValue.GetHelperText(1);
        library.taskHelper.ShowSimpleTask(str);
    }

    protected override string Description()
    {
        return taskValue.GetFullText(0) + " " + attempts + " " + taskValue.GetFullText(GetPadej(attempts));
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();
        flightControll = library.car.GetComponent<FlightController>();
    }

    new void Update()
    {
        base.Update();
    }


}
