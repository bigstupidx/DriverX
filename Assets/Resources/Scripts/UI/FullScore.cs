using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullScore : MonoBehaviour {

    Text text;
    int fullScore;
    Library library;
    int savedBigFullScore;
    int bigFullScore;
    void Start()
    {
        text = GetComponent<Text>();
        library = GameObject.FindObjectOfType<Library>();
        UpdateBigFullScore();
        UpdateText();
    }


    public void AddScore(int addScore)
    {
        fullScore += addScore;
        bigFullScore = savedBigFullScore + fullScore;
        UpdateText();
    }

    public int GetScore()
    {
        return fullScore;
    }

    public void ClearScore()
    {
        fullScore = 0;

        UpdateBigFullScore();
        
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = fullScore+"" /*+ " (" + bigFullScore+")"*/;

    }


    void UpdateBigFullScore()
    {
        savedBigFullScore = library.preferencesSaver.GetIntTaskValue(1, "Points");


        bigFullScore = savedBigFullScore + fullScore;
    }

    public void SaveBigFullScore()
    {
        library.preferencesSaver.SaveTaskValue(1, "Points", bigFullScore+"");
   }

    public int GetBigFullScore()
    {
        return bigFullScore;
    }
}
