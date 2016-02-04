using UnityEngine;
using System.Collections;

public class DestroyZnaki : Task
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
        return taskValue.GetFullText(0) + fullCount + " (" + lastCount + ") "+ taskValue.GetFullText(GetPadej(fullCount));
    }

    new void Update()
    {
        base.Update();
    }

    private void MyAction(int count)
    {

        string str = taskValue.GetHelperText(0) + " " + count + "/" + fullCount + " " + taskValue.GetHelperText(3);
        library.taskHelper.ShowTask(str);
    }

    protected override void Conditions()
    {
        int count = library.car.GetComponent<CarContact>().GetDestroyableCount("RoadSign");

        if (lastCount != count)
        {
            MyAction(count);
        }

        lastCount = count;
        if (count == fullCount)
            SetJustComplete();
    }

}
