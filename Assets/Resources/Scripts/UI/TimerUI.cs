using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerUI : MonoBehaviour {
    Text text;
    Library library;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        library = GameObject.FindObjectOfType<Library>();
    }

    // Update is called once per frame
    void Update () {
        text.text =  library.timerScript.GetTimeLeft().ToString("F1");
	}


}
