using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyBar : MonoBehaviour {

    public Text money;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
       money.text = "^ "+ Bank.GetMoney() + "";
	}
}
