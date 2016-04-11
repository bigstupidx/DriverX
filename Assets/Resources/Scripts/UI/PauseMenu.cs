using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public ScrollBoxController scrollBoxController;
    Library library;

    public GameObject pauseButtons;
    public GameObject endButtons;

    public GameObject startPauseMenu;


	// Use this for initialization
	void Start () {
    //    scrollBoxController = GameObject.FindObjectOfType<ScrollBoxController>();
        library = GameObject.FindObjectOfType<Library>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    public void CloseMenu()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }*/

    public void OpenPauseMenu()
    {
        OpenMenu();
        endButtons.SetActive(false);
        startPauseMenu.SetActive(false);
        pauseButtons.SetActive(true);

    }

    public void OpenEndMenu()
    {
        OpenMenu();
        pauseButtons.SetActive(false);
        startPauseMenu.SetActive(false);
        endButtons.SetActive(true);
    }

    public void OpenStartPauseMenu()
    {
        OpenMenu();
        pauseButtons.SetActive(false);
        endButtons.SetActive(false);
        startPauseMenu.SetActive(true);

        startPauseMenu.GetComponent<StartPauseMenu>().ToDefault();
    }

    private void OpenMenu()
    {
        /*
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);*/

        scrollBoxController.UpdateDiscription();
        scrollBoxController.ToDefaultPosition();

        Time.timeScale = 0;
    //    library.canvasController.ShowGameUI(false);
      //  library.inputController.gameObject.SetActive(false);
      //  library.gameUI.gameObject.SetActive(false);
        
    }

    public void ClearTasks()
    {
        if (scrollBoxController != null)
        {
            bool isActive = scrollBoxController.gameObject.activeInHierarchy;

            if (!isActive)
                scrollBoxController.gameObject.SetActive(true);

            scrollBoxController.ClearTasks();
        }

    }

    public TaskItem AddTask(Task task)
    {
        //gameObject.SetActive(true);
        bool isActive = scrollBoxController.gameObject.activeInHierarchy;

        if (!isActive)
            scrollBoxController.gameObject.SetActive(true);
        TaskItem ti= scrollBoxController.AddTask(task);
        //gameObject.SetActive(false);
        return ti;
    }
}
