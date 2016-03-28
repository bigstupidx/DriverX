using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskHelper : MonoBehaviour {

    Text text;
    int tempToHide;

    IEnumerator currentCoroutine; 
   
    void Start () {
        text = GetComponent<Text>();
        text.enabled = false;
    }


    void ShowTask(string str)
    {
        text.enabled = true;
        text.text = str;

        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = HideText();
        StartCoroutine(currentCoroutine);
    }

    public void ShowWinTask(string str)
    {
        tempToHide = 3;
        ShowTask(str);
        text.color = Color.yellow;
    }

    public void ShowSimpleTask(string str)
    {
        tempToHide = 2;
        ShowTask(str);
        text.color = Color.white;
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(tempToHide);
        text.text = "";
        text.enabled = false;
       
    }
}
