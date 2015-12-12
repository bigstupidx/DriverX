﻿using UnityEngine;
using System.Collections;

public class Bank{

    static int gold = PreferencesSaver.GetGold();
    static int money = PreferencesSaver.GetMoney();

    public static int GetGold()
    {
        return gold;
    }

    public static int GetMoney()
    {
        return money;
    }

    public static void PlusGold(int m_gold)
    {
        gold += m_gold;

        PreferencesSaver.SetGold(gold);
    }

    public static void MinusGold(int m_gold)
    {
        gold -= m_gold;

        if (gold < 0)
            gold = 0;
        PreferencesSaver.SetGold(gold);

    }

    public static void PlusMoney(int m_money)
    {
        money += m_money;

        PreferencesSaver.SetMoney(money);

    }

    public static void MinusMoney(int m_money)
    {
        money -= m_money;
    
        if (money < 0)
            money = 0;

        PreferencesSaver.SetMoney(money);

    }

}