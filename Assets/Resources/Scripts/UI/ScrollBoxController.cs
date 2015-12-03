using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScrollBoxController : MonoBehaviour {

    public float border =0;
    Library library;
    RectTransform rt;
    GameObject taskItemPrefab;
    int itemCount;

    GameObject scrollBox;
    // Use this for initialization
    void Start () {
        library = GameObject.FindObjectOfType<Library>();

        rt = GetComponent<RectTransform>();

        taskItemPrefab = Resources.Load("Prefabs/UI/TaskItem") as GameObject;

        scrollBox = transform.FindChild("ScrollBox").gameObject;

        //library.pauseMenu.CloseMenu();
        library.canvasController.ShowPauseMenu(false);

        //AddTasks();
    }


    public GameObject AddTask(Task task)
    {
        itemCount++;
        GameObject taskItem = Instantiate(taskItemPrefab) as GameObject;
        taskItem.transform.SetParent(scrollBox.transform, false);
        RectTransform rectTransform = taskItem.GetComponent<RectTransform>();
        Vector3 ancoredPos = rectTransform.anchoredPosition;
        ancoredPos.y = ((rectTransform.rect.height + border) * (itemCount-1) + 0.5f * rectTransform.rect.height + border) * (-1);
        rectTransform.anchoredPosition = ancoredPos;
        taskItem.transform.FindChild("MainText").GetComponent<Text>().text = task.GetDescription();
        taskItem.transform.FindChild("Reward").GetComponent<Text>().text = task.reward+"";

        scrollBox.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollBox.GetComponent<RectTransform>().sizeDelta.x, (taskItemPrefab.GetComponent<RectTransform>().sizeDelta.y + border)* itemCount+border);
        return taskItem;
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
        SBRT.anchoredPosition = new Vector2(SBRT.anchoredPosition.x, (rt.rect.height - scrollBox.GetComponent<RectTransform>().rect.height) / 2);
    }

    
}
