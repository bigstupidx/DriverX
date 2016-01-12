using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {

    // Use this for initialization
    Library library;

	void Start () {
        library = GetComponent<Library>();
        SetToDefault();
	}
	
	public void SetToDefault()
    {
        library.mainBonus.MinusItem();

        if (library.level == null)
        {
            library.level = GameObject.FindGameObjectWithTag("Level");
            
            return;
        }

        Destroy(library.level);
        

        GameObject newLevel = Instantiate(Resources.Load("Prefabs/Levels/LevelDesert")) as GameObject;
        library.level = newLevel;
        library.pauseMenu.ClearTasks();

        library.carCreator.UpdateCar();


        library.energy.ToDefault();

        library.wordRideCanvas.ToDefault();

        library.cam.GetComponent<CameraMotion>().ToDefaultPosition();
     //   library.cam.GetComponentInChildren<EZCameraShake.CameraShaker>().ClearShakeInstances();

        library.fullScore.ClearScore();

        library.timerScript.ToDefault();

        library.canvasController.HideEndMenu();
        library.canvasController.ShowGameUI();
        library.canvasController.ShowInput();

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
        library.canvasController.ShowBaraban();
      //  Time.timeScale = 0;
    }


}
