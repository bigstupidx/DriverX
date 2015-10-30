using UnityEngine;
using System.Collections;

public class DestroyAllWalls : Task
{

    int fullCount;

    int lastCount;
    // Use this for initialization
    new void Start()
    {
        base.Start();

        fullCount = GameObject.Find("Betonfances").transform.childCount;
    }

    protected override string Description()
    {
        return taskValue.GetFullText(0);
    }

    new void Update()
    {
        base.Update();
    }

    private void MyAction(int count)
    {
        string str = taskValue.GetHelperText(0) + " " + count + "/" + fullCount + " " + taskValue.GetHelperText(1);
        library.taskHelper.ShowTask(str);
    }

    protected override void Conditions()
    {
        int count = library.car.GetComponent<CarContact>().GetDestroyableCount("Wall");

        if (lastCount != count)
        {
            MyAction(count);
        }

        lastCount = count;
        if (count == fullCount)
            SetJustComplete();
    }
}
