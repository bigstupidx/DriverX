using UnityEngine;
using System.Collections;

public class FindLevelExit : Task
{


    bool isTake;
    protected override void Conditions()
    {
        if (isTake)
            SetJustComplete();
    }



    protected override string Description()
    {
        return taskValue.GetFullText(0);
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();

        if (IsComplete())
        {
            Destroy(GameObject.FindObjectOfType<FinalPoint>().gameObject);
        }
    }

    new void Update()
    {
        base.Update();
    }

    public void SetTake()
    {
        isTake = true;
    }
}
