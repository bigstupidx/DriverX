using UnityEngine;
using System.Collections;

public class Bank {

    static int gold = PreferencesSaver.GetGold();
    static int money = PreferencesSaver.GetMoney();
    static int barabanBooster = PreferencesSaver.GetBarabanBooster();

    static int[] freeBooster = { PreferencesSaver.GetFreeBoosterCount(0), PreferencesSaver.GetFreeBoosterCount(1), PreferencesSaver.GetFreeBoosterCount(2) };


    public static int GetGold()
    {
        return gold;

    }

    public static int GetMoney()
    {
        return money;
    }

    public static int GetBarabanBooster()
    {
        return barabanBooster;
    }


    public static int GetFreeBooster(int num)
    {
        return freeBooster[num];
    }


    public static void PlusGold(int m_gold)
    {
        gold += m_gold;

        PreferencesSaver.SetGold(gold);
    }



    public static void PlusMoney(int m_money)
    {
        money += m_money;

        PreferencesSaver.SetMoney(money);

    }



    public static void PlusBarabanBooster(int val)
    {
        barabanBooster += val;

        PreferencesSaver.SetBarabanBooster(barabanBooster);

    }


    public static void PlusFreeBooster(int numBooster, int val)
    {
        freeBooster[numBooster] += val;

        PreferencesSaver.SetFreeBoosterCount(numBooster,freeBooster[numBooster]);

    }

    public static void MinusGold(int m_gold)
    {
        gold -= m_gold;

        if (gold < 0)
            gold = 0;
        PreferencesSaver.SetGold(gold);

    }
    public static void MinusMoney(int m_money)
    {
        money -= m_money;

        if (money < 0)
            money = 0;

        PreferencesSaver.SetMoney(money);

    }

    public static void MinusBarabanBooster(int val)
    {
        barabanBooster -= val;

        if (barabanBooster < 0)
            barabanBooster = 0;

        PreferencesSaver.SetBarabanBooster(barabanBooster);

    }

    public static void MinusFreeBooster(int numBooster, int val)
    {
        freeBooster[numBooster] -= val;

        if (freeBooster[numBooster] < 0)
            freeBooster[numBooster] = 0;

        PreferencesSaver.SetFreeBoosterCount(numBooster, freeBooster[numBooster]);

    }


}
