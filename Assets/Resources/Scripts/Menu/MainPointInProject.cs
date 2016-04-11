using UnityEngine;
using System.Collections;
using UnityEngine.CrashLog;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;



public class MainPointInProject : MonoBehaviour {

    string appKeyAppodeal = "996fb26603205d24a63ca120b711d0dd6526bc4ec47ccd67";


    // Use this for initialization
    void Awake () {
        InitCrashReporting();
        InitAppodeal();
        PreferencesSaver.AddEnterCount();

    }
	
    void InitCrashReporting()
    {
        CrashReporting.Init("dac0461d-78c6-453e-893f-3495b4994a9d");

    }

    void InitAppodeal()
    {
        Appodeal.initialize(appKeyAppodeal, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
    }

    public static void ShowStaticAd()
    {
        #if UNITY_ANDROID
        if(!PreferencesSaver.PurchaseIsComplete())
            Appodeal.show(Appodeal.INTERSTITIAL);
        #endif
    }
}
