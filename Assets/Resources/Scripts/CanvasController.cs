using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

    GameUI gameUI;
    InputController inputController;
    PauseMenu pauseMenu;
    Baraban baraban;
    EndMenu endMenu;
	// Use this for initialization
	void Start ()  {
        gameUI = GameObject.FindObjectOfType<GameUI>();
        inputController = GameObject.FindObjectOfType<InputController>();
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        baraban = GameObject.FindObjectOfType<Baraban>();
        endMenu = GameObject.FindObjectOfType<EndMenu>();

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
        pauseMenu.OpenMenu();
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
        baraban.gameObject.SetActive(true);
        baraban.UseBaraban();
    }

    public void HideBaraban()
    {
        baraban.gameObject.SetActive(false);
    }

    public void ShowEndMenu()
    {
        HideBaraban();
        endMenu.gameObject.SetActive(true);
    }

    public void HideEndMenu()
    {
        endMenu.gameObject.SetActive(false);
    }

    public void ToDefault()
    {
        ShowGameUI();
        ShowInput();
        HideBaraban();
        HidePauseMenu();
        HideEndMenu();
    }

    public Baraban GetBaraban()
    {
        return baraban;
    }


}
