using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Task : MonoBehaviour {

    protected TaskValue taskValue;
    protected Library library;

    private bool isComplete;
    protected bool justComplete;

    protected GameObject item;

    protected string description;

    // Use this for initialization
    protected void Start() {
        library = GameObject.FindObjectOfType<Library>();
        taskValue = library.taskStrings.GetTaskValue(this.GetType().Name);
        description = Description();
     
        library.pauseMenu.SetActive(true);
        item = library.pauseMenu.GetComponentInChildren<ScrollBoxController>().AddTask(this);
        library.pauseMenu.SetActive(false);

        if (library.preferencesSaver.TaskIsComplete(1, this.GetType().Name))
        {
            isComplete = true;
            SetColored();
        }
    }

    abstract protected string Description();
	
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
        return description;
    }

    public bool IsComplete()
    {
        return isComplete;
    }

    public bool JustComplete()
    {
        return justComplete;
    }

    public void SetItem(GameObject item)
    {
        this.item = item;
    }

    public void SetComplete()
    {
        isComplete = true;
    }

    public void SetColored()
    {
        Color oldColor = item.GetComponent<Image>().color;
        item.GetComponent<Image>().color = new Color(0, 1, 0, oldColor.a);
    }

    protected void SetJustComplete()
    {
        SetComplete();
        SetColored();
        library.preferencesSaver.SaveTaskComplete(1, this.GetType().Name);
        justComplete = true;
    }
}
