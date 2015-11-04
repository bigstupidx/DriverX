using UnityEngine;
using System.Collections;

public class KAController : MonoBehaviour {

    LibraryMenu libraryMenu;

    MonoBehaviour currentObject;

    void Start()
    {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        ToDefault();
    }

    void ToDefault()
    {
        libraryMenu.taskMenu.gameObject.SetActive(false);
        libraryMenu.waitBackground.ToDefault();
    }

	public void ShowGarage()
    {
        HideCurrent();
        currentObject = libraryMenu.garage;
        ShowCurrent();
    }

    public void ShowTasksMenu()
    {
        HideCurrent();
        currentObject = libraryMenu.taskMenu;
        ShowCurrent();
    }

    void HideAll()
    {
        libraryMenu.taskMenu.gameObject.SetActive(false);
        libraryMenu.garage.gameObject.SetActive(false);
    }

    void HideCurrent()
    {
        if(currentObject != null)
        currentObject.gameObject.SetActive(false);
    }

    void ShowCurrent()
    {
        if(currentObject != null)
        currentObject.gameObject.SetActive(true);
    }

    public void ShowLevel()
    {
        libraryMenu.waitBackground.Show();
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {  
        AsyncOperation async = Application.LoadLevelAsync("1234");
        yield return async; 
    }
}
