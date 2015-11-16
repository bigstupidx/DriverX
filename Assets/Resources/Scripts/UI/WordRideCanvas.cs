using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WordRideCanvas : MonoBehaviour {

    GameObject[] letters;
    GameObject full;
    IEnumerator currentCourutine;
	// Use this for initialization
	void Start () {
        letters = new GameObject[4];
        full = transform.FindChild("Full").gameObject;


        letters[0] = full.transform.FindChild("R").gameObject;
        letters[1] = full.transform.FindChild("I").gameObject;
        letters[2] = full.transform.FindChild("D").gameObject;
        letters[3] = full.transform.FindChild("E").gameObject;

        ToDefault();

	}
	
    public void ToDefault()
    {
        foreach (GameObject GO in letters)
        {
            GO.SetActive(false);
        }
        full.SetActive(false);

    }

    public void ShowLetter(int num)
    {
        if(currentCourutine != null)
        {
            StopCoroutine(currentCourutine);
            currentCourutine = null;
        }

        full.SetActive(true);
        letters[num].SetActive(true);
        letters[num].transform.localScale = new Vector3(4f, 4f, 4f);

        iTween.ScaleTo(letters[num].gameObject,
           iTween.Hash(
               "scale", new Vector3(1, 1, 1),
               "time", 0.45f,
              /* "onstart", (System.Action<object>)(newVal => logo1.color = new Color(logo1.color.r, logo1.color.g, logo1.color.b, 1)),*/
               "easetype", iTween.EaseType.easeInCubic,
               "oncomplete", "ShakeCamera",
               "oncompletetarget", gameObject
               )
            );

        currentCourutine = HideFull();
        StartCoroutine(currentCourutine);
    }

    IEnumerator HideFull()
    {
        yield return new WaitForSeconds(3);
/*
        foreach(GameObject letter in letters)
        {
            Fade(letter);
        }

        Fade(full);
        */
        full.SetActive(false);
    }

    void Fade(GameObject GO)
    {
        iTween.ValueTo(GO,
        iTween.Hash("from", 1,
        "to", 0,
         "time", 1f,
        "onupdate", (System.Action<object>)(newVal => {
          RawImage RI = GO.GetComponent<RawImage>();
          RI.color = new Color(RI.color.r, RI.color.g, RI.color.b, (float)newVal);
      }
      ),
      "oncomplete", (System.Action<object>)(newVal => full.SetActive(false)),
      "easetype", iTween.EaseType.linear,
      "oncompletetarget", gameObject
      )
     );
    }

    void ShakeCamera()
    {
        iTween.ShakePosition(gameObject,
            iTween.Hash(
                "amount", new Vector3(5, 5, 5),
                "time", 0.8f
                )
            );
    }
}
