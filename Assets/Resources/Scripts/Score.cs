using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    Library library;

    float timer;

	void Start () {
        library = GetComponent<Library>();
	}

    public void AddScoreForDestroy(Destroyable destroyable)
    {
        library.currentScore.AddScrore(destroyable.GetCost());
        timer = 2;
    }

    void Update()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0);

        if(timer == 0)
        {
            CurrentScoreToFullScore();
        }


    }

    void CurrentScoreToFullScore()
    {
        if (!library.currentScore.IsZero())
        {
            library.fullScore.AddScore(library.currentScore.GetScore());
            library.currentScore.ClearScore();
        }
    }

}
