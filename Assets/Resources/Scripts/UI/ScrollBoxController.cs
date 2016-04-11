using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

public class ScrollBoxController : MonoBehaviour {

    public float border =0;
    Library library;
    GameObject taskItemPrefab;
    int itemCount;

    List<Task> tasks = new List<Task>();

    public GameObject scrollBox;
    // Use this for initialization
    void Start () {
        library = GameObject.FindObjectOfType<Library>();


        taskItemPrefab = Resources.Load("Prefabs/UI/TaskItem") as GameObject;

//        scrollBox = transform.FindChild("ScrollBox").gameObject;

        //library.pauseMenu.CloseMenu();
     //   library.canvasController.ShowPauseMenu(false);

        //AddTasks();
    }


    public TaskItem AddTask(Task task)
    {
        tasks.Add(task);

        itemCount++;
        GameObject taskItemGO = Instantiate(taskItemPrefab) as GameObject;
        taskItemGO.transform.SetParent(scrollBox.transform, false);
        RectTransform rectTransform = taskItemGO.GetComponent<RectTransform>();
        Vector3 ancoredPos = rectTransform.anchoredPosition;
        ancoredPos.y = ((rectTransform.rect.height + border) * (itemCount-1) + 0.5f * rectTransform.rect.height + border) * (-1);
        rectTransform.anchoredPosition = ancoredPos;

        scrollBox.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollBox.GetComponent<RectTransform>().sizeDelta.x, (taskItemPrefab.GetComponent<RectTransform>().sizeDelta.y + border)* itemCount+border);
        return taskItemGO.GetComponent<TaskItem>();
    }

    public void ClearTasks()
    {
        itemCount = 0;
        foreach(Transform child in scrollBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ToDefaultPosition()
    {
        RectTransform SBRT = scrollBox.GetComponent<RectTransform>();
        SBRT.anchoredPosition = new Vector2(SBRT.anchoredPosition.x, (GetComponent<RectTransform>().rect.height - scrollBox.GetComponent<RectTransform>().rect.height) / 2);
    }

    public void UpdateDiscription()
    {

        foreach (Task task in tasks)
        {

            task.UpdateConditions();
        }

    }
    
}
