using UnityEngine;
using System.Collections;

public class KAController : MonoBehaviour {

    LibraryMenu libraryMenu;

    MonoBehaviour currentObject;

    [HideInInspector] public static bool garageWillShow = false;

    void Start()
    {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        currentObject = libraryMenu.mainScreen;
        ToDefault();
    }

    void ToDefault()
    {
        libraryMenu.dailyGiftMenu.gameObject.SetActive(false);
        libraryMenu.garage.gameObject.SetActive(false);
        libraryMenu.moneyBar.gameObject.SetActive(false);
        libraryMenu.taskMenu.gameObject.SetActive(false);
        libraryMenu.boosterMenu.gameObject.SetActive(false);
        libraryMenu.waitBackground.ToDefault();
        libraryMenu.mainScreen.ToDefault();
    }

	public void ShowGarage()
    {
        HideCurrent();
        currentObject = libraryMenu.garage;
        ShowCurrent();

        

        libraryMenu.garage.ToDefault();
        /*
        if(!garageWillShow)
        {
            libraryMenu.dailyGiftMenu.ShowDailyGiftMenu();
            //libraryMenu.dailyEvents.RateApp();
        }
        */
        garageWillShow = true;
    }

    public void ShowDailyGiftMenu()
    {
        HideCurrent();
        currentObject = libraryMenu.dailyGiftMenu;
        ShowCurrent();



        libraryMenu.dailyGiftMenu.ToDefault();
    }

    public void ShowTasksMenu()
    {
        HideCurrent();
        currentObject = libraryMenu.taskMenu;
        ShowCurrent();
    }

    public void ShowBoosterMenu()
    {
        HideCurrent();
        currentObject = libraryMenu.boosterMenu;
        ShowCurrent();

  //      libraryMenu.boosterMenu.UpdateValues();
    }

    void HideAll()
    {
        libraryMenu.taskMenu.gameObject.SetActive(false);
        libraryMenu.garage.gameObject.SetActive(false);
    }

    void HideCurrent()
    {
        
        if(currentObject != null)
        {
            if(currentObject == libraryMenu.garage)
            {
                libraryMenu.fireStart.GetComponent<Particle>().StopLoop();

            }

            currentObject.gameObject.SetActive(false);
        }
    }

    void ShowCurrent()
    {
        if (currentObject != null)
        {
            if (currentObject == libraryMenu.garage || currentObject == libraryMenu.boosterMenu)
                libraryMenu.moneyBar.gameObject.SetActive(true);

            if (currentObject == libraryMenu.garage)
            {
                libraryMenu.carChanger.car.SetActive(true);
            }

            if (currentObject == libraryMenu.taskMenu)
            {
                libraryMenu.moneyBar.gameObject.SetActive(false);
                libraryMenu.carChanger.car.SetActive(false);
            }
        }
        currentObject.gameObject.SetActive(true);
    }

    public void ShowLevel()
    {
        libraryMenu.waitBackground.Show();
        StartCoroutine(StartLevel());
    }

   

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(1);

        AsyncOperation async = Application.LoadLevelAsync("k123");
       
        yield return async; 
    }
}
