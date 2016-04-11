using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarabanScore : MonoBehaviour {

    int score;
    int coef =4;
    int fullScore;
    int tempFullScore;
    Text text;


    Material redColor;
    Material blueColor;

    //  Color yellowColor = new Color(255/255f, 215/255f, 0/255f, 255/255f);
    //Color blueColor = new Color(45 / 255f, 45 / 255f, 255 / 255f, 255/255f);
    Library library;
    public Particle fireParticle;
    public Particle smokeParticle;

    Vector3 startScale;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
      //  redColor = Resources.Load("Font/font1") as Material;
     //   blueColor = Resources.Load("Font/font2") as Material;

        library = GameObject.FindObjectOfType<Library>();
        startScale = new Vector3( text.gameObject.transform.localScale.x, text.gameObject.transform.localScale.y, text.gameObject.transform.localScale.z);
    }
	
    public void SetScore(int score)
    {

     //   fireParticle.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

 //       smokeParticle.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

  //      if (!fireParticle.GetParticle().loop)
  //          fireParticle.PlayLoop();

        this.score = score;
        text.text = score+"";
      //  text.material = redColor;
    }

    public void AddCoef()
    {
        text.text = score + " x "+coef;

        fullScore = score * coef;

        tempFullScore = fullScore;



        iTween.ScaleTo(text.gameObject,
          iTween.Hash(
              "scale",StaticValues.maxScaleTextInMenu,
              "time", StaticValues.timeToScaleTextInMenu,
              "ignoretimescale", true,
              "easetype", iTween.EaseType.easeOutCubic
          )
      );

        iTween.ScaleTo(text.gameObject,
         iTween.Hash(
              "scale", startScale,
             "delay", StaticValues.timeToScaleTextInMenu,
              "ignoretimescale", true,
             "time", StaticValues.timeToScaleTextInMenu,
             "easetype", iTween.EaseType.easeInCubic
         )
     );

        StartCoroutine(ShowCoefSum());
    }

	public IEnumerator ShowCoefSum()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(2));
        //    fireParticle.StopLoop();
        //  smokeParticle.GetParticle().Play();

        //     text.material = blueColor;

        text.text = fullScore + "";

        StartCoroutine(ShowMenu());
    }

    public IEnumerator ShowNoCoefSum()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1));
        //  fireParticle.StopLoop();
        //  smokeParticle.GetParticle().Play();

        //    text.material = blueColor;

        fullScore = score;

        tempFullScore = fullScore;

        text.text = fullScore + "";

        StartCoroutine(ShowMenu());
    }

    IEnumerator ShowMenu()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1));

        library.fullScore.SaveBigFullScore(fullScore);
        library.canvasController.GetBaraban().ConvertToMoney();
       // library.canvasController.ShowEndMenu();
    }

    public int GetFullScore()
    {
        return fullScore;
    }

    public int GetTempFullScore()
    {
        return tempFullScore;
    }

    public void SetTempFullScore(int val)
    {
        tempFullScore = val;
        text.text = val + "";
    }
}
