using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Task : MonoBehaviour {

    protected string taskDescription;
    protected Library library;

    private bool isComplete;
    protected bool justComplete;

    protected GameObject item;

    // Use this for initialization
    protected void Start() {
        library = GameObject.FindObjectOfType<Library>();
        taskDescription = library.taskStrings.GetString(this.GetType().Name);

        if (library.preferencesSaver.TaskIsComplete(1, this.GetType().Name))
        {
            isComplete = true;
        }
    }


	
    protected void Update()
    {

    }

	public string GetDescription()
    {
        return taskDescription;
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
