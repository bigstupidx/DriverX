using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

    Button button;

    Library library;

    void Start()
    {
        button = GetComponent<Button>();

        library = GameObject.FindObjectOfType<Library>();

        button.onClick.AddListener(delegate { ShowMenu(); gameObject.SetActive(false);});
    }

    void ShowMenu()
    {
        //library.pauseMenu.OpenMenu();
        library.canvasController.ShowPauseMenu();
    }
}
