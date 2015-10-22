using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {

    // Use this for initialization
    Library library;
	void Start () {
        library = GetComponent<Library>();
	}
	
	public void SetToDefault()
    {


        GameObject newLevel = Instantiate(Resources.Load("Prefabs/Levels/Level4")) as GameObject;
        library.level = newLevel;

        Destroy(GameObject.Find("Level4"));
        
        library.car.GetComponent<CarController>().ToStartPosition();
        library.car.GetComponent<CarUserControl>().ToDefault();

        library.cam.GetComponent<CameraMotion>().ToDefaultPosition();
        library.cam.GetComponentInChildren<CameraShaker>().ClearShakeInstances();

        library.fullScore.ClearScore();

        library.timerScript.ToDefault();
    }

    public void TimerIsEnd()
    {
        library.car.GetComponent<CarUserControl>().SetEnd();
        StartCoroutine(CheckIsStay());
    }

    IEnumerator CheckIsStay()
    {
        while (true)
        {
            if(library.car.GetComponent<CarUserControl>().IsStay())
            {
                StartCoroutine(PartyTime());
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator PartyTime()
    {
        library.score.CurrentScoreToFullScore();
        yield return new WaitForSeconds(1.5f);
        library.endMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
