using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FullScore : MonoBehaviour {

    Text text;
    int fullScore;
    Library library;
    int savedBigFullScore;
    int bigFullScore;
    int finalScore;

    void Start()
    {
        text = GetComponent<Text>();
        library = GameObject.FindObjectOfType<Library>();
        savedBigFullScore = PreferencesSaver.GetIntTaskValue(1, "Points");
        bigFullScore = savedBigFullScore;
        UpdateText();
    }


    public void AddScore(int addScore)
    {
        fullScore += addScore;
        bigFullScore = savedBigFullScore + fullScore;
        UpdateText();
    }


    public void ClearScore()
    {
        fullScore = 0;

        
        UpdateText();
    }

    public void UpdateText()
    {
        if(!text.text.Equals(fullScore+""))
            text.text = fullScore+"";

    }

    public int GetFullScore()
    {
        return fullScore;
    }



    public void SaveBigFullScore(int finalScore)
    {
        this.finalScore = finalScore;
        bigFullScore = savedBigFullScore + finalScore;
        PreferencesSaver.SaveTaskValue(1, "Points", bigFullScore+"");
   }

    public int GetBigFullScore()
    {
        return bigFullScore;
    }
}
