using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyBar : MonoBehaviour {

    public Text money;
    public Text gold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        gold.text = Bank.GetGold() + "";
        money.text = Bank.GetMoney() + "";
	}
}
