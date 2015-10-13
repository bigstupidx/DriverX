using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScrollBoxController : MonoBehaviour {

    public float border = 20;
    Library library;
    RectTransform rt;
	// Use this for initialization
	void Start () {

        library = GameObject.FindObjectOfType<Library>();

        rt = GetComponent<RectTransform>();


        AddTasks();

        transform.parent.gameObject.SetActive(false);
    }

    private void AddTasks()
    {
        Task[] taskScripts = library.tasks.GetComponents<Task>();
        GameObject taskItemPrefab = Resources.Load("Prefabs/UI/TaskItem") as GameObject;

        for (int i = 0; i < taskScripts.Length; i++)
        {
            GameObject taskItem = Instantiate(taskItemPrefab) as GameObject;
            taskItem.transform.SetParent(transform, false);
            RectTransform rectTransform = taskItem.GetComponent<RectTransform>();
            Vector3 ancoredPos = rectTransform.anchoredPosition;
            ancoredPos.y = ((rectTransform.rect.height) * (i + 0.5f) + border) * (-1);
            rectTransform.anchoredPosition = ancoredPos;
            taskItem.GetComponentInChildren<Text>().text = taskScripts[i].GetDescription();
            taskScripts[i].SetItem(taskItem);

            if (taskScripts[i].IsComplete())
                taskScripts[i].SetColored();
        }

        rt.sizeDelta = new Vector2(rt.sizeDelta.x, (taskItemPrefab.GetComponent<RectTransform>().sizeDelta.y + border)*taskScripts.Length+border);
    }

    
}
