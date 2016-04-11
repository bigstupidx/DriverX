using UnityEngine;
using System.Collections;

public class DestroyBoxesInCombo : Task
{

    public int fullCountInCombo;

    int lastCount;

    int lastComboNum;

    int lastCountInCombo = 0;
    // Use this for initialization
    new void Start()
    {
        base.Start();

    }

    protected override string Description()
    {
        return taskValue.GetFullText(0) + " "+fullCountInCombo +" " + taskValue.GetFullText(Padej.GetPadej(fullCountInCombo));
    }

    new void Update()
    {
        base.Update();
    }

    private void MyAction(int count)
    {

        string str = taskValue.GetHelperText(0) + " " + count + "/" + fullCountInCombo + " " + taskValue.GetHelperText(1);
        library.taskHelper.ShowSimpleTask(str);
    }



    protected override void Conditions()
    {
        int count = library.car.GetComponent<CarContact>().GetDestroyableCount("CartonBox");

        if (lastCount != count)
        {
            int currentComboNum = library.score.GetComboNum();

            if (currentComboNum != lastComboNum)
                lastCountInCombo = 0;
            
            lastCountInCombo++;

            MyAction(lastCountInCombo);

            lastComboNum = currentComboNum;

        }

        lastCount = count;

        if (lastCountInCombo == fullCountInCombo)
        {
            SetJustComplete();
        }
    }
}