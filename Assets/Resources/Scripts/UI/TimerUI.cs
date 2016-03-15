using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerUI : MonoBehaviour {
    Text text;
    Library library;
    string current = "0";
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        library = GameObject.FindObjectOfType<Library>();

    }

    // Update is called once per frame
    void Update () {

        string temp = library.timerScript.GetTimeLeft().ToString("F1");

        if (!temp.Equals(current))
        text.text = temp;

        current = temp;

    }


}
