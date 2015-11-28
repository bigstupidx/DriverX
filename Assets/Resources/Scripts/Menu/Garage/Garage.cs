using UnityEngine;
using System.Collections;

public class Garage : MonoBehaviour {

    CarChanger carChanger;
    LibraryMenu libraryMenu;
	// Use this for initialization
	void Start () {
        carChanger = transform.GetComponentInChildren<CarChanger>();
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToDefault()
    {
        carChanger.ToDefault();
        libraryMenu.fireStart.GetComponent<Particle>().PlayLoop();
    }

}
