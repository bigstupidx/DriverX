using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class MenuButton : MonoBehaviour {

    protected Button button;
    protected LibraryMenu libraryMenu;
    // Use this for initialization
    public void Start()
    {
        button = GetComponent<Button>();

        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        button.onClick.AddListener(
            delegate
            {
                OnClick();
            }
        );
    }

    protected abstract void OnClick();
}
