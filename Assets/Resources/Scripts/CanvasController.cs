using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

    GameUI gameUI;
    InputController inputController;
    PauseMenu pauseMenu;
    Baraban baraban;
    EndMenu endMenu;
    public GameObject timeIsOver;
    Library library;
  
	// Use this for initialization
	void Start ()  {
        gameUI = GameObject.FindObjectOfType<GameUI>();
        inputController = GameObject.FindObjectOfType<InputController>();
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        baraban = GameObject.FindObjectOfType<Baraban>();
        endMenu = GameObject.FindObjectOfType<EndMenu>();

        library = GameObject.FindObjectOfType<Library>();

        ToDefault();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowGameUI()
    {
            gameUI.gameObject.SetActive(true);
    }

    public void HideGameUI()
    {
        gameUI.gameObject.SetActive(false);
    }

    public void ShowInput()
    { 
            inputController.gameObject.SetActive(true);
    }

    public void HideInput()
    {
        inputController.gameObject.SetActive(false);
    }

    public void ShowPauseMenu()
    {

        HideGameUI();
        HideInput();
        HideBaraban();
        pauseMenu.gameObject.SetActive(true);
        pauseMenu.OpenPauseMenu();
    }

    public void HidePauseMenu()
    {
        ShowGameUI();
        ShowInput();
        pauseMenu.gameObject.SetActive(false);
    }

    public void ShowBaraban()
    {
        HideGameUI();
        HideInput();
        HideTimeIsOver();
        baraban.gameObject.SetActive(true);
        baraban.ToDefault();
        //baraban.UseBaraban();
    }

    public void HideBaraban()
    {
        baraban.gameObject.SetActive(false);
    }

    public void ShowEndMenu()
    {
        HideBaraban();

        pauseMenu.gameObject.SetActive(true);


        pauseMenu.OpenEndMenu();
    }

    public void HideEndMenu()
    {
        pauseMenu.gameObject.SetActive(false);

    }

    public void ToDefault()
    {
        ShowGameUI();
        ShowInput();
        HideBaraban();
        HidePauseMenu();
        HideEndMenu();
        timeIsOver.SetActive(false);

        //HideGameUI();
        //HideInput();
    }

    public Baraban GetBaraban()
    {
        return baraban;
    }


    public void ShowTimeIsOver()
    {
        timeIsOver.SetActive(true);
        timeIsOver.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);

        iTween.ScaleTo(timeIsOver.gameObject,
         iTween.Hash(
             "scale", new Vector3(1, 1, 1),
             "time", 0.45f,
             /* "onstart", (System.Action<object>)(newVal => logo1.color = new Color(logo1.color.r, logo1.color.g, logo1.color.b, 1)),*/
             "easetype", iTween.EaseType.easeInCubic,
             "oncomplete", "ShakeCamera",
             "oncompletetarget", gameObject
             )
          );
    }

    void ShakeCamera()
    {
        /*
        iTween.ShakePosition(library.cam,
            iTween.Hash(
                "amount", new Vector3(0.5f, 0.5f, 0.5f),
                "time", 0.8f
                )
            );*/
        EZCameraShake.CameraShakeInstance c = EZCameraShake.CameraShaker.Instance.ShakeOnce(2, 15, 0.1f, 1f);

    }

    public void HideTimeIsOver()
    {
        timeIsOver.SetActive(false);
    }

}
