using UnityEngine;
using System.Collections;
using System;

public class DestroyRedBarrel : Task
{

    public int fullCount;

    int lastCount;
    // Use this for initialization
    new void Start()
    {
        base.Start();

    }

    protected override string Description()
    {
        return taskValue.GetFullText(0)+" " + fullCount+ " ("+lastCount+ ") " + taskValue.GetFullText(Padej.GetPadej(fullCount));
    }

    new void Update()
    {
        base.Update();
    }

    private void MyAction(int count)
    {

        string str = taskValue.GetHelperText(0) + " " + count + "/" + fullCount + " " + taskValue.GetHelperText(1);
        library.taskHelper.ShowSimpleTask(str);
    }

    protected override void Conditions()
    {
        int count = library.car.GetComponent<CarContact>().GetDestroyableCount("BarrelRed");

        if (lastCount != count)
        {
            MyAction(count);
        }

        lastCount = count;
        if (count == fullCount)
            SetJustComplete();
    }


}
