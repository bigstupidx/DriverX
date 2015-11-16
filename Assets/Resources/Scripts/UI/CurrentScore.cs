using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentScore : MonoBehaviour {

    Text text;

    int score;
    int coef;
    int fullScore;

    Material redColor;
    Material blueColor;

    //  Color yellowColor = new Color(255/255f, 215/255f, 0/255f, 255/255f);
    //Color blueColor = new Color(45 / 255f, 45 / 255f, 255 / 255f, 255/255f);

    IEnumerator currentCoroutine;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        redColor = Resources.Load("Font/font1") as Material;
        blueColor = Resources.Load("Font/font2") as Material;
    }

    public void AddScoreAndCoef(int addScore, bool isCoef)
    {
        if(isCoef)
            coef += 1;

        score += addScore;
        fullScore = coef * score;

        ShowScore();
        
    }

   

    private void ShowScore()
    {
        text.text = score + " X " + coef;
        text.material = redColor;

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
    }


    public int GetFullScore()
    {
        return fullScore;
    }

    public void ClearScore()
    {
        text.material = blueColor;

        text.text = fullScore+"";

        score = 0;
        coef = 0;
        fullScore = 0;

        currentCoroutine = HideScore();
        StartCoroutine(currentCoroutine);
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
