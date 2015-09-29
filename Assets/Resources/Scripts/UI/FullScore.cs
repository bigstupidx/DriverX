using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullScore : MonoBehaviour {

    Text text;
    int fullScore;
    Library library;
    void Start()
    {
        text = GetComponent<Text>();
        library = GameObject.FindObjectOfType<Library>();
        text.text = fullScore + "/" + library.score.GetScoreToWin();

    }


    public void AddScore(int addScore)
    {
        fullScore += addScore;
        text.text = fullScore + "/"+ library.score.GetScoreToWin();
    }
}
