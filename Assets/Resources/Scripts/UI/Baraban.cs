using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Baraban : MonoBehaviour {

    public GameObject arrow;
    public BarabanScore barabanScore;

    public Text reward;

    public RawImage[] sectors = new RawImage[10];

    public Texture lightImage;
    public Texture darkImage;

    float chanse;

    const float BonusCost = 5;
    const float StandartCost = 1;

    float timer;
    const int CoefScoreToMoney = 100;

    int tempReward;
    int fullReward;
    // Use this for initialization
    Library library;
	void Start () {
        library = GameObject.FindObjectOfType<Library>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateSectors()
    {
        if (library.mainBonus.IsAvailable())
        {
            chanse = (BonusCost+StandartCost)/10f;

            for(int i = 0; i < BonusCost + StandartCost ; i++)
            {
                sectors[i].texture = lightImage;
            }

            for (int i = (int)(BonusCost + StandartCost); i < sectors.Length; i++)
            {
                sectors[i].texture = darkImage;
            }
        }
        else
        {
            chanse = StandartCost/10f;

            for (int i = 0; i < StandartCost; i++)
            {
                sectors[i].texture = lightImage;
            }

            for (int i = (int)(StandartCost); i < sectors.Length; i++)
            {
                sectors[i].texture = darkImage;
            }
        }
    }

    void Rotate()
    {
        arrow.transform.rotation = Quaternion.Euler(0, 0, 0);

        float random = Random.Range(0, 100) / 100f;

        while (random % 0.1f < 0.01f && random % 0.1f > 0)
        {
            random = Random.Range(0, 100) / 100f;
        }

        iTween.RotateBy(arrow, 
            iTween.Hash(
                "delay",0.5f,
                "z",-(4f + random),
                "speed", 250,
                "oncomplete", (System.Action<object>)(newVal => {
                    if(random <= chanse)
                        StartCoroutine(UpdatePoints(true));
                    else
                        StartCoroutine(UpdatePoints(false));
                }),
                "easetype", iTween.EaseType.easeOutCubic,
                "oncompletetarget", gameObject
            )
        );
    }

    public void UseBaraban()
    {
        barabanScore.SetScore(library.fullScore.GetFullScore());
        reward.text = "% 0";
        UpdateSectors();

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
            reward.text = "% "+tempReward;



            if (tempFullScore == 0)
                break;

            yield return new WaitForEndOfFrame();
        }
        fullReward = tempReward;

        Bank.PlusMoney(fullReward);

        yield return new WaitForSeconds(2f);

        library.globalController.gs = GlobalController.GameState.RetryMenu;
        library.canvasController.ShowEndMenu();

    }
}
