using UnityEngine;
using System.Collections;

public abstract class Task : MonoBehaviour {

    protected string taskDescription;
    Library library;
    // Use this for initialization
	protected void Start () {
        library = GameObject.FindObjectOfType<Library>();

        taskDescription = library.taskStrings.GetString(this.GetType().Name);
	}
	
	public string GetDescription()
    {
        return taskDescription;
    }
}
