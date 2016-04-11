using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyBar : MonoBehaviour {

    public Text money;

    int moneyVal = 0;

	// Use this for initialization
	void Start () {

        Update();
	}
	
	// Update is called once per frame
	void Update () {
            
        if(moneyVal != Bank.GetMoney())
            money.text = "^ "+ Bank.GetMoney() + "";

        moneyVal = Bank.GetMoney();

    }
}
