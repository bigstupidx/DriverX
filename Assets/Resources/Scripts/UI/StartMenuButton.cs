using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : RawButton
{


    Library library;
    Button button;
    new void Start()
    {
        base.Start();
        library = GameObject.FindObjectOfType<Library>();
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate { HideMenu(); ShowPauseButton();  });


    }

    void HideMenu()
    {
        //library.pauseMenu.CloseMenu();
        library.canvasController.HidePauseMenu();

        //if (library != null)
          //  library.globalController.StartCar();
    }

    void ShowPauseButton()
    {
        library.pauseButton.SetActive(true);
    }

}
