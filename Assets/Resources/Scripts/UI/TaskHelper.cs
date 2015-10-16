using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskHelper : MonoBehaviour {

    Text text;

    IEnumerator currentCoroutine; 
   
    void Start () {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void ShowTask(string str)
    {
        text.text = str;

        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = HideText();
        StartCoroutine(currentCoroutine);
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2);
        text.text = "";

    }
}
