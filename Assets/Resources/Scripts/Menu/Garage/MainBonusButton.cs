using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBonusButton : MonoBehaviour {

    public Text count;
    public Text time;

    LibraryMenu libraryMenu;
	// Use this for initialization
	void Start () {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
	}
	
	// Update is called once per frame
	void Update () {

        if (MainBonus.MaxValue == MainBonus.count)
            time.text = "";

        count.text = MainBonus.count+"";

        int minutes = (int)  MainBonus.RecoveryTime/60 - libraryMenu.mainBonus.GetSubtractMinutes();
        int seconds = 60 - libraryMenu.mainBonus.GetSubtractSeconds();

        time.text = minutes+" : "+seconds;
         
	}
}
