using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MainBonusButton : MonoBehaviour {

    public Text count;
    public Text time;
    public GameObject image;
    LibraryMenu libraryMenu;

	// Use this for initialization
	void Start () {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
	}
	
	// Update is called once per frame
	void Update () {


        count.text = "% "+ MainBonus.count + "";


        if (MainBonus.MaxValue <= MainBonus.count)
        {
            time.text = "";

            if(image.activeSelf)
            image.SetActive(false);
        }
        else
        {


            //   int seconds = MainBonus.RecoveryTime % 60 - libraryMenu.mainBonus.GetSubtractSeconds();
            //  if (seconds < 0)
            //       seconds += 60;

            //    int minutes = (int) Mathf.Ceil(MainBonus.RecoveryTime / 60f)   - libraryMenu.mainBonus.GetSubtractMinutes() - (int)Mathf.Ceil(seconds / 60f);

            if (!image.activeSelf)
                image.SetActive(true);

            TimeSpan ts = libraryMenu.mainBonus.GetSubtract();

            time.text = ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
        }
	}


}
