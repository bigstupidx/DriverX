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
        return taskValue.GetFullText(0) + fullCount + taskValue.GetFullText(GetPadej(fullCount));
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

    int GetPadej(int fullCount)
    {
        int strNum = 1;

        if ((fullCount >= 10 && fullCount <= 20) || fullCount % 10 >= 5)
            strNum = 3;
        else if (fullCount % 10 == 1)
            strNum = 1;
        else if (fullCount % 10 >= 2 && fullCount % 10 <= 4)
            strNum = 2;

        return strNum;
    }
}
