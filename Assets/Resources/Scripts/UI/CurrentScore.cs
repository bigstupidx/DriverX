using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentScore : MonoBehaviour {

    Text text;

    int score;
    int coef;
    int fullScore;

    Color yellowColor = new Color(255/255f, 215/255f, 0/255f, 255/255f);
    Color blueColor = new Color(45 / 255f, 45 / 255f, 255 / 255f, 255/255f);

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}

    public void AddScrore(int addScore)
    {
        coef += 1;
        score += addScore;
        fullScore = coef * score;

        text.text = score + " X " + coef;
        text.color = yellowColor;
    }

    public int GetScore()
    {
        return score;
    }

    public void ClearScore()
    {
        text.color = blueColor;

        text.text = fullScore+"";

        score = 0;
        coef = 0;
        fullScore = 0;

        StartCoroutine(HideScore());
    }

    IEnumerator HideScore()
    {
        yield return new WaitForSeconds(1);
        text.text = "";

    }

    public bool IsZero()
    {
        if (fullScore == 0)
            return true;
        else
            return false;
    }

	
	
}
