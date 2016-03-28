using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DailyEvents : MonoBehaviour {

    LibraryMenu libraryMenu;
    string appURL = "https://play.google.com/store/apps/details?id=com.sveta.gonka";
    // Use this for initialization
    void Start ()
    {
        libraryMenu = GetComponent<LibraryMenu>();
	}
	
    public void RateApp()
    {
        if (!PreferencesSaver.AppIsRate())
        {
            int enterCount = PreferencesSaver.GetEnterCount();

            if (enterCount == 2 ||(enterCount > 2 && enterCount%4 == 0))
            {
                Button buttonOk = libraryMenu.windowConfirmation.button1;
               


                buttonOk.onClick.AddListener(
                    delegate
                    {
                        Application.OpenURL(appURL);
                        PreferencesSaver.SetRateApp();
                    }
                );


                libraryMenu.windowConfirmation.Show("Если понравилась игра - сделай нам приятное. Оцени её, пожалуйста.");
            }
        }
        
    }
}
