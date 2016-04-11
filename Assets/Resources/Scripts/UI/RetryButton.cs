using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryButton : RawButton {

    Button button;
    Library library;

	// Use this for initialization
	new void Start () {

        base.Start();

        library = FindObjectOfType<Library>();

        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { ReloadLevel(); });

    }
	
    void ReloadLevel()
    {
        library.waitBackground.Show();
        StartCoroutine(GlobalToDefault());

    }

    IEnumerator GlobalToDefault()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1.5f));
        library.globalController.SetToDefault();

    }

}
