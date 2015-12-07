using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowConfirmation : MonoBehaviour
{
    public Text text;
    public Button button1;
    public Button button2;

    public void Start()
    {
        button1.onClick.AddListener(
              delegate
              {
                  Hide();
              }
          );

        button2.onClick.AddListener(
              delegate
              {
                  Hide();
              }
          );
    }

    public void Show(string val)
    {
        text.text = val;

        foreach (Transform child in transform)
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