using UnityEngine;

using UnityEngine.UI;
using System.Collections;

public abstract class Task : MonoBehaviour {

    protected TaskValue taskValue;
    protected Library library;

    private bool isComplete;
    protected bool justComplete;

    protected TaskItem item;


    public int reward;

    // Use this for initialization
    protected void Start() {
        library = GameObject.FindObjectOfType<Library>();
        taskValue = library.taskStrings.GetTaskValue(this.GetType().Name);
        
        item = library.pauseMenu.AddTask(this);

        item.SetDescription(GetDescription());
        item.SetReward(reward + "");

        if (PreferencesSaver.TaskIsComplete(1, this.GetType().Name))
        {
            SetComplete();
            item.SetDone();
        }
    }

    abstract protected string Description();
    protected void MyActionComplete()
    {
        string str = TextStrings.GetString("done")+": "+ Description();
        library.taskHelper.ShowWinTask(str);
    }
	
    protected void Update()
    {   
        if (!IsComplete())
        {
            Conditions();
        }
    }

    abstract protected void Conditions();

	public string GetDescription()
    {
        return Description();
    }



    public bool IsComplete()
    {
        return isComplete;
    }

    public bool JustComplete()
    {
        return justComplete;
    }

    public void SetItem(TaskItem item)
    {
        this.item = item;
    }

    public void SetComplete()
    {
        isComplete = true;
    }



    protected void SetJustComplete()
    {
        MyActionComplete();
        SetComplete();
        item.SetDone();
        PreferencesSaver.SaveTaskComplete(1, this.GetType().Name);
        justComplete = true;
    }


    public void UpdateConditions()
    {
        item.SetDescription(GetDescription());
    }


  
}
