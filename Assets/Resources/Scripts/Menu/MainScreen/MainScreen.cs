using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScreen : MonoBehaviour {

    public RawImage logo1;
    public RawImage logo2;
    public RawImage pressToStart;
    public Image bg;

    public LibraryMenu libraryMenu;
    public Button button;
	// Use this for initialization
	void Start () {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        logo1 = transform.FindChild("FirstLogo").GetComponent<RawImage>();
        logo2 = transform.FindChild("SecondLogo").GetComponent<RawImage>();
        bg = GetComponent<Image>();
        pressToStart = transform.FindChild("PressToStart").GetComponent<RawImage>();
        button = transform.FindChild("Button").GetComponent<Button>();


        button.onClick.AddListener(
            delegate
            {
                libraryMenu.fireBackground.GetComponent<Particle>().StopLoop();

                if (libraryMenu.dailyGiftMenu.CanShow())
                    libraryMenu.kaController.ShowDailyGiftMenu();
                else
                    libraryMenu.kaController.ShowGarage();
            }
        );

    }
	
    public void ToDefault()
    {
        logo2.color = new Color(logo2.color.r, logo2.color.g, logo2.color.b, 0);
        logo1.color = new Color(logo2.color.r, logo2.color.g, logo2.color.b, 0);
        button.enabled = false;
        pressToStart.color = new Color(pressToStart.color.r, pressToStart.color.g, pressToStart.color.b, 0);
        logo1.transform.localScale = new Vector3(8f, 8f, 8f);
        ShowLogo();

    }



    void ShowLogo()
    {
        iTween.ScaleTo(logo1.gameObject,
            iTween.Hash(
                "scale", new Vector3(1, 1, 1), 
                "delay", 0.2f,
                "time", 0.45f,
                "onstart", (System.Action<object>)(newVal => { logo1.color = new Color(logo1.color.r, logo1.color.g, logo1.color.b, 1); StartCoroutine(StartFireBG());}),
                "easetype", iTween.EaseType.easeInCubic,
                "oncomplete", "ShakeCamera",
                "oncompletetarget", gameObject
                )
             );




        iTween.ValueTo(gameObject,
            iTween.Hash("from", 0,
             "to", 1,
              "time", 0.5f,
              "delay", 2f,
             "onupdate", (System.Action<object>)(newVal => logo2.color = new Color(logo2.color.r, logo2.color.g, logo2.color.b, (float)newVal)),
             "oncomplete", "OnCompleteShowLogo",
             "oncompletetarget", gameObject
             )


        );
    }

    IEnumerator StartFireBG()
    {
        yield return new WaitForSeconds(1.4f);


        Image img = GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);


        libraryMenu.fireBackground.GetComponent<Particle>().PlayLoop();
        libraryMenu.dustSmall.GetComponent<Particle>().PlayLoop();
    }



    void OnCompleteShowLogo()
    {
        button.enabled = true;
        ShowPressStart();
    }

    void ShakeCamera()
    {
        iTween.ShakePosition(gameObject,
            iTween.Hash(
                "amount", new Vector3(10,10, 10),
                "time", 0.8f
                
                )
            );

        iTween.ShakePosition(libraryMenu.bg,
            iTween.Hash(
                "amount", new Vector3(1, 1, 1),
                "time", 0.8f
                
                )
            );


    }

    void ShowPressStart()
    {
        iTween.ValueTo(gameObject,
        iTween.Hash("from", 0,
         "to", 1,
          "time", 1.5f,
         "onupdate", (System.Action<object>)(newVal => pressToStart.color = new Color(pressToStart.color.r, pressToStart.color.g, pressToStart.color.b, (float)newVal)),
         "oncomplete", "HidePressStart",
         "easetype", iTween.EaseType.linear,
         "oncompletetarget", gameObject
         )
        );
    }

    void HidePressStart()
    {
        iTween.ValueTo(gameObject,
        iTween.Hash("from", 1,
         "to", 0,
          "time", 1.5f,
         "onupdate", (System.Action<object>)(newVal => pressToStart.color = new Color(pressToStart.color.r, pressToStart.color.g, pressToStart.color.b, (float)newVal)),
         "oncomplete", "ShowPressStart",
         "easetype", iTween.EaseType.linear,
         "oncompletetarget", gameObject
         )
        );
    }
    /*
    void OnFadeLogo(float newVal)
    {
        logo2.color = new Color(logo2.color.r, logo2.color.g, logo2.color.b, (float)newVal);
    }*/
}
