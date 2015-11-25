using UnityEngine;
using System.Collections;

public class Garage : MonoBehaviour {

    CarChanger carChanger;
	// Use this for initialization
	void Start () {
        carChanger = transform.GetComponentInChildren<CarChanger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToDefault()
    {
        carChanger.ToDefault();
    }

}
