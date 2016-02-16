using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    [HideInInspector] public ScrollBoxController scrollBoxController;
    Library library;

    public GameObject pauseButtons;
    public GameObject endButtons;

	// Use this for initialization
	void Start () {
        scrollBoxController = GameObject.FindObjectOfType<ScrollBoxController>();
        library = GameObject.FindObjectOfType<Library>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseMenu()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        OpenMenu();
        pauseButtons.SetActive(true);
        endButtons.SetActive(false);
    }

    public void OpenEndMenu()
    {
        OpenMenu();
        pauseButtons.SetActive(false);
        endButtons.SetActive(true);
    }

    private void OpenMenu()
    {
        /*
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);*/

        scrollBoxController.UpdateDiscription();
        scrollBoxController.ToDefaultPosition();

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
