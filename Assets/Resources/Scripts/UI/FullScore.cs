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
        UpdateText();
    }

    public int GetScore()
    {
        return fullScore;
    }

    public void ClearScore()
    {
        fullScore = 0;
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = fullScore + "/" + library.score.GetScoreToWin();

    }
}
