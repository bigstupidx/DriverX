using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskItem : MonoBehaviour {

    public Text description;
    public Text reward;
    public GameObject done;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDescription(string str)
    {
        description.text = str;
    }

    public void SetReward(string str)
    {
        reward.text = str;
    }

    public void SetDone()
    {
        done.SetActive(true);
    }
}
