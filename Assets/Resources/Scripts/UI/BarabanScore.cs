using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarabanScore : MonoBehaviour {

    int score;
    int coef =4;
    int fullScore;

    Text text;


    Material redColor;
    Material blueColor;

    //  Color yellowColor = new Color(255/255f, 215/255f, 0/255f, 255/255f);
    //Color blueColor = new Color(45 / 255f, 45 / 255f, 255 / 255f, 255/255f);
    Library library;
    public Particle fireParticle;
    public Particle smokeParticle;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        redColor = Resources.Load("Font/font1") as Material;
        blueColor = Resources.Load("Font/font2") as Material;

        library = GameObject.FindObjectOfType<Library>();
       
    }
	
    public void SetScore(int score)
    {

        fireParticle.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        smokeParticle.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        if (!fireParticle.GetParticle().loop)
            fireParticle.PlayLoop();

        this.score = score;
        text.text = score+"";
        text.material = redColor;
    }

    public void AddCoef()
    {
        text.text = score + " x "+coef;

        fullScore = score * coef;

        float delay = 0.1f;

        Vector3 scale = text.transform.localScale;

        iTween.ScaleTo(text.gameObject,
          iTween.Hash(
              "scale",new Vector3(1,1,1),
              "time", delay,
              "easetype", iTween.EaseType.easeOutCubic
          )
      );

        iTween.ScaleTo(text.gameObject,
         iTween.Hash(
              "scale", new Vector3(0.52f,0.52f,0.52f),
             "delay", delay,
             "time", delay,
             "easetype", iTween.EaseType.easeInCubic
         )
     );

        StartCoroutine(ShowCoefSum());
    }

	public IEnumerator ShowCoefSum()
    {
        yield return new WaitForSeconds(2);
        fireParticle.StopLoop();
        smokeParticle.GetParticle().Play();

        text.material = blueColor;

        text.text = fullScore + "";

        StartCoroutine(ShowMenu());
    }

    public IEnumerator ShowNoCoefSum()
    {
        yield return new WaitForSeconds(1);
        fireParticle.StopLoop();
        smokeParticle.GetParticle().Play();

        text.material = blueColor;

        fullScore = score;

        text.text = fullScore + "";

        StartCoroutine(ShowMenu());
    }

    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2);

        library.fullScore.SaveBigFullScore(fullScore);
        library.canvasController.ShowEndMenu();
    }
}
