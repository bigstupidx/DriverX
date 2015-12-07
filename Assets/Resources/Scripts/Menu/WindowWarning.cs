using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowWarning : MonoBehaviour {

    public Text text;
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(
              delegate
              {
                  Hide();
              }
          );
    }


    public void Show(string val)
    {
        text.text = val;

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

       
    }

    public void Hide()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
