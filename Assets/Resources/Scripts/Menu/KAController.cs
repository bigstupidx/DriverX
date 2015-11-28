using UnityEngine;
using System.Collections;

public class KAController : MonoBehaviour {

    LibraryMenu libraryMenu;

    MonoBehaviour currentObject;

    void Start()
    {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        currentObject = libraryMenu.mainScreen;
        ToDefault();
    }

    void ToDefault()
    {
        libraryMenu.garage.gameObject.SetActive(false);
        libraryMenu.taskMenu.gameObject.SetActive(false);
        libraryMenu.waitBackground.ToDefault();
        libraryMenu.mainScreen.ToDefault();
    }

	public void ShowGarage()
    {
        HideCurrent();
        currentObject = libraryMenu.garage;
        ShowCurrent();
        libraryMenu.garage.ToDefault();

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
        {
            if(currentObject == libraryMenu.garage)
            {
                libraryMenu.fireStart.GetComponent<Particle>().StopLoop();
            }

            currentObject.gameObject.SetActive(false);
        }
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
