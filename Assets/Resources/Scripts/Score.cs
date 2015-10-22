using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    Library library;

    float timer;

    int scoreToWin;

    int lastCombo;

	void Start () {
        library = GetComponent<Library>();
        scoreToWin = 20000;
	}

    public void AddScoreForDestroy(Destroyable destroyable)
    {
        AddScoreAndCoef(destroyable.GetCost(), true);
    }

    private void AddScoreAndCoef(int cost, bool isCoef)
    {
        library.currentScore.AddScoreAndCoef(cost, isCoef);
        timer = 2;
    }

    public void AddScore(int cost)
    {
        AddScoreAndCoef(cost, false);
    }

    public void AddCoef()
    {
        AddScoreAndCoef(0, true);
    }





    void Update()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0);

        if(timer == 0)
        {
            CurrentScoreToFullScore();
        }


    }

    public void CurrentScoreToFullScore()
    {
        if (!library.currentScore.IsZero())
        {
            lastCombo = library.currentScore.GetFullScore();
            library.fullScore.AddScore(lastCombo);
            library.currentScore.ClearScore();
        }
    }

    public int GetScoreToWin()
    {
        return scoreToWin;
    }

    public int GetLastCombo()
    {
        return lastCombo;
    }

}
