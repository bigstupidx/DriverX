using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Baraban : MonoBehaviour {

    public GameObject arrow;
    public BarabanScore barabanScore;

    public RawImage[] sectors = new RawImage[10];

    public Texture lightImage;
    public Texture darkImage;

    float chanse;

    const float BonusCost = 5;
    const float StandartCost = 1;

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
        UpdateSectors();

        Rotate();
    }

    

    IEnumerator UpdatePoints(bool val)
    {
        yield return new WaitForSeconds(1);

        if (val)
            barabanScore.AddCoef();
        else
            StartCoroutine(barabanScore.ShowNoCoefSum());
        //library.canvasController.ShowEndMenu();
    }
}
