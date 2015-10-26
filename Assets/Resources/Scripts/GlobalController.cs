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
        Destroy(library.level);

        library.level = newLevel;
        library.pauseMenu.SetActive(true);
        library.pauseMenu.GetComponentInChildren<ScrollBoxController>().ClearTasks();
        library.pauseMenu.SetActive(false);
        
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
        BeforeShowMenu();
        yield return new WaitForSeconds(1.5f);
        ShowMenu();


    }

    void BeforeShowMenu()
    {
        library.score.CurrentScoreToFullScore();
    }

    void ShowMenu()
    {
        library.endMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        library.fullScore.SaveBigFullScore();
    }
}
