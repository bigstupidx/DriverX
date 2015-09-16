using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullScore : MonoBehaviour {

    Text text;
    int fullScore;

    void Start()
    {
        text = GetComponent<Text>();
    }


    public void AddScore(int addScore)
    {
        fullScore += addScore;
        text.text = fullScore + "";
    }
}
