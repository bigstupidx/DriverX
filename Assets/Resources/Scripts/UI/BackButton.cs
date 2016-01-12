using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : RawButton {

    
    Library library;
    Button button;
    new void Start()
    {
        base.Start();
        library = GameObject.FindObjectOfType<Library>();
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate { HideMenu(); ShowPauseButton(); Time.timeScale = 1; });

       
    }

    void HideMenu()
    {
        //library.pauseMenu.CloseMenu();
        library.canvasController.HidePauseMenu();
    }

    void ShowPauseButton()
    {
        library.pauseButton.SetActive(true);
    }

}
