using UnityEngine;
using System.Collections;
using System;

public class DailyGiftMenu : MonoBehaviour {

    GameObject giftPrefab;

    public GameObject scrollBox;

    int borderWidth = 10;

    LibraryMenu libraryMenu;

    Gift currentGift;
    int numDailyGift;
    // Use this for initialization
    void Start()
    {

        numDailyGift = PreferencesSaver.GetNextDailyGiftNum();

        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        giftPrefab = Resources.Load("Prefabs/UI/Gift") as GameObject;

        scrollBox.GetComponent<RectTransform>().sizeDelta = new Vector2((giftPrefab.GetComponent<RectTransform>().sizeDelta.x + borderWidth) * (DailyGiftXml.GetGiftCount() - 1) + 800, giftPrefab.GetComponent<RectTransform>().sizeDelta.y);

        for (int i = 0; i < DailyGiftXml.GetGiftCount(); i++)
        {
            Gift gift = DailyGiftXml.GetGift(i);

            GameObject giftGO = Instantiate(giftPrefab) as GameObject;
            giftGO.transform.SetParent(scrollBox.transform, false);

            RectTransform rectTransform = giftGO.GetComponent<RectTransform>();
            Vector3 ancoredPos = rectTransform.anchoredPosition;

            ancoredPos.x = ((rectTransform.rect.width + borderWidth) * i + 400);
            rectTransform.anchoredPosition = ancoredPos;

            GiftGO giftS = giftGO.GetComponent<GiftGO>();
            giftS.SetGift(gift, i + 1);

            if (i == numDailyGift)
            {
                currentGift = gift;
                giftS.SetToday();
            }
        }

    }
	

    public void GetGift()
    {
        switch(currentGift.type)
        {
            case Gift.GiftType.Money: Bank.PlusMoney(currentGift.val1); break;       
            case Gift.GiftType.Booster1: Bank.PlusFreeBooster(0,currentGift.val1); break;
            case Gift.GiftType.Booster2: Bank.PlusFreeBooster(1, currentGift.val1); break;
            case Gift.GiftType.Booster3: Bank.PlusFreeBooster(2, currentGift.val1); break;
            case Gift.GiftType.Bonus: libraryMenu.mainBonus.AddItem(currentGift.val1); break;
        }

        PreferencesSaver.SetDailyGiftDate(System.DateTime.Now);
        PreferencesSaver.SetNextDailyGiftNum();
        libraryMenu.kaController.ShowGarage();
    }

    public bool CanShow()
    {

        DateTime dt = PreferencesSaver.GetDailyGiftDate();
        DateTime ndt = System.DateTime.Now;

        if(dt.Day < ndt.Day || dt.Month < ndt.Month || dt.Year < ndt.Year)
        {
            return true;
        }

        return false;
    }

    public void ToDefault()
    {
        scrollBox.GetComponent<RectTransform>().anchoredPosition 
            = new Vector2(
                (giftPrefab.GetComponent<RectTransform>().sizeDelta.x + borderWidth)*(DailyGiftXml.GetGiftCount()/2f - 1) 
                + (giftPrefab.GetComponent<RectTransform>().sizeDelta.x+borderWidth)/2f 
                - (giftPrefab.GetComponent<RectTransform>().sizeDelta.x + borderWidth)*numDailyGift, 
                scrollBox.GetComponent<RectTransform>().anchoredPosition.y);
    }

}
