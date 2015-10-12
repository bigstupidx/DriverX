using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : MonoBehaviour {

    Button button;
    Library library;
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate { HideMenu(); ShowPauseButton(); Time.timeScale = 1; });
    }

    void HideMenu()
    {
        transform.parent.gameObject.SetActive(false);
    }

    void ShowPauseButton()
    {
        library.pauseButton.SetActive(true);
    }

}
