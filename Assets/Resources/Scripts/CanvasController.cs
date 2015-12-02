using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

    GameUI gameUI;
    InputController inputController;
    PauseMenu pauseMenu;
	// Use this for initialization
	void Start ()  {
        gameUI = GameObject.FindObjectOfType<GameUI>();
        inputController = GameObject.FindObjectOfType<InputController>();
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowGameUI(bool val)
    {
            gameUI.gameObject.SetActive(val);
    }

    public void ShowInput(bool val)
    { 
            inputController.gameObject.SetActive(val);
    }

    public void ShowPauseMenu(bool val)
    {

        ShowGameUI(!val);
        ShowInput(!val);
        pauseMenu.gameObject.SetActive(val);
        pauseMenu.OpenMenu();
    }
}
