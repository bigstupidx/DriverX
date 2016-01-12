using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour {

    Button button;
    Library library;
	// Use this for initialization
	void Start () {
        library = FindObjectOfType<Library>();

        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { ReloadLevel(); Time.timeScale = 1; });

    }
	
    void ReloadLevel()
    {
          library.globalController.SetToDefault();

    }

}
