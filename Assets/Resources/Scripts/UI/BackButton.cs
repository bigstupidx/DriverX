using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : RawButton {

    
    Library library;
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
        library.canvasController.ShowPauseMenu(false);
    }

    void ShowPauseButton()
    {
        library.pauseButton.SetActive(true);
    }

}
