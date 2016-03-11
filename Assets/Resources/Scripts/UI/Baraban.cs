using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Baraban : MonoBehaviour {

    public BarabanScore barabanScore;

    public Text reward;

    //public RawImage[] sectors = new RawImage[10];

    public Button startBarabanButton;
    public Button boosterButton;

    public Text bonusText;

    public GameObject sectors;


    const int BonusCost = 5;
    const int StandartCost = 1;

    float timer;
    const int CoefScoreToMoney = 100;

    int tempReward;
    int fullReward;

    bool isWinBaraban;

    Vector3 startScale;

    // Use this for initialization
    Library library;
	void Start () {
        library = GameObject.FindObjectOfType<Library>();

        startBarabanButton.onClick.AddListener(delegate { UseBaraban(); startBarabanButton.gameObject.SetActive(false); boosterButton.gameObject.SetActive(false); });

        startScale = new Vector3(bonusText.gameObject.transform.localScale.x, bonusText.gameObject.transform.localScale.y, bonusText.gameObject.transform.localScale.z);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void UpdateSectors()
    {
        sectors.GetComponent<BarabanSectorContainer>().ToDefault();

     //   if (library.mainBonus.IsAvailable())
      //      chanse = (BonusCost+StandartCost);

       // else


        sectors.GetComponent<BarabanSectorContainer>().SetActiveElements(StandartCost);

    }

    void Rotate()
    {
        int random = Random.Range(0, 10);
        isWinBaraban = sectors.GetComponent<BarabanSectorContainer>().IsActive(random);

        float apX = sectors.GetComponent<RectTransform>().anchoredPosition.x;
        float rectW = sectors.GetComponent<RectTransform>().rect.width;

        iTween.ValueTo(sectors,
            iTween.Hash("from", apX,
            "to", apX+rectW*4 - random * rectW/10f - rectW/10f/2f,
             "speed", 400,
            "onupdate", (System.Action<object>)(newVal => sectors.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)newVal, sectors.GetComponent<RectTransform>().anchoredPosition.y)),

             "oncomplete", (System.Action<object>)(newVal => {
                     StartCoroutine(UpdatePoints(isWinBaraban));
                 
             }),

         "easetype", iTween.EaseType.easeOutCubic,
         "oncompletetarget", gameObject
         )
        );
 
         }

    public void UseBaraban()
    {
        Rotate();
    }

    

    IEnumerator UpdatePoints(bool val)
    {
        yield return new WaitForSeconds(0);

        if (val)
            barabanScore.AddCoef();
        else
            StartCoroutine(barabanScore.ShowNoCoefSum());
        //library.canvasController.ShowEndMenu();
    }

    public void ConvertToMoney()
    {
     //   barabanScore.GetComponent<Text>().text = 0+"";
    //    reward.text = "% " + barabanScore.GetFullScore() / 10;

        StartCoroutine(ConvertCoroutine());
    }

    IEnumerator ConvertCoroutine()
    {
        while (true)
        {
            int tempFullScore = barabanScore.GetTempFullScore();



            timer += Time.deltaTime;

            float mnozitel = barabanScore.GetFullScore() / 3f;

            float preValScore = timer * mnozitel;

            int valScore = (int)Mathf.Floor(preValScore);

            timer = (preValScore - valScore)/mnozitel;


            tempFullScore = (int) Mathf.Clamp(tempFullScore - valScore,0,10000000000000000000);



            barabanScore.SetTempFullScore(tempFullScore);

            tempReward = (int)Mathf.Ceil((barabanScore.GetFullScore() - tempFullScore) / CoefScoreToMoney);
            reward.text = "^ "+tempReward;



            if (tempFullScore == 0)
                break;

            yield return new WaitForEndOfFrame();
        }
        fullReward = tempReward;

        Bank.PlusMoney(fullReward);

        yield return new WaitForSeconds(2f);

        library.globalController.gs = GlobalController.GameState.RetryMenu;

        if(isWinBaraban)
            MainPointInProject.ShowStaticAd();

        library.canvasController.ShowEndMenu();

    }

    public void ToDefault()
    {
        barabanScore.SetScore(library.fullScore.GetFullScore());
        reward.text = "^ 0";

        if(library.mainBonus.IsAvailable())
            bonusText.text = "% "+(MainBonus.count+1);
        else
            bonusText.text = "% " + MainBonus.count;


        UpdateSectors();


        startBarabanButton.gameObject.SetActive(true);
        boosterButton.gameObject.SetActive(true);

        boosterButton.GetComponent<BarabanBoosterButton>().ToDefault();


        if (library.mainBonus.IsAvailable())
        {
            StartCoroutine(UseBonus());
            startBarabanButton.GetComponent<RawButton>().DisableButton();
            boosterButton.GetComponent<RawButton>().DisableButton();
        }
    }


    IEnumerator UseBonus()
    {
        yield return new WaitForSeconds(0.5f);
        bonusText.text = "% " + (MainBonus.count);

        iTween.ScaleTo(bonusText.gameObject,
                iTween.Hash(
                    "scale", StaticValues.maxScaleTextInMenu,
                    "time", StaticValues.timeToScaleTextInMenu,
                    "easetype", iTween.EaseType.easeOutCubic
                    )
             );

        iTween.ScaleTo(bonusText.gameObject,
         iTween.Hash(
              "scale", startScale,
              "delay", StaticValues.timeToScaleTextInMenu,
              "time", StaticValues.timeToScaleTextInMenu,
              "easetype", iTween.EaseType.easeInCubic,
              "oncomplete", (System.Action<object>)(newVal => {
                  ShowFiveBonus();
              }),
              "oncompletetarget", gameObject
         )
     );
    }

    void ShowFiveBonus()
    {
        ShowBonus(BonusCost);
        startBarabanButton.GetComponent<RawButton>().EnableButton();
        boosterButton.GetComponent<BarabanBoosterButton>().UpdateStatusButton();
    }

    public void ShowBonus(int count)
    {
        GameObject[] objects = sectors.GetComponent<BarabanSectorContainer>().SetActiveElements(count);


        for (int i = 0; i < objects.Length; i++)
        {
            GameObject img = objects[i].GetComponent<BarabanSector>().numImg;
            img.transform.localScale = new Vector3(2f, 2f, 2f);

            iTween.ScaleTo(img,
              iTween.Hash(
                  "scale", new Vector3(1, 1, 1),
                  "time", 0.45f,
                  "easetype", iTween.EaseType.easeInCubic,
                  "oncompletetarget", gameObject
                  )
               );
        }
        ShakeCamera();

    }

    void ShakeCamera()
    {
        iTween.ShakePosition(library.cam,
            iTween.Hash(
                "delay", 0.45f,
                "amount", new Vector3(0.5f, 0.5f, 0.5f),
                "time", 0.8f
                )
            );
    }

}
