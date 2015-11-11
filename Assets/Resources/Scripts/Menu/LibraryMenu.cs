using UnityEngine;
using System.Collections;

public class LibraryMenu : MonoBehaviour {

    [HideInInspector] public Garage garage;
    [HideInInspector] public TaskMenu taskMenu;
    [HideInInspector] public KAController kaController;
    [HideInInspector] public WaitBackground waitBackground;
    [HideInInspector] public MainScreen mainScreen;
	// Use this for initialization
	void Start () {
        garage = GameObject.FindObjectOfType<Garage>();
        taskMenu = GameObject.FindObjectOfType<TaskMenu>();
        kaController = GameObject.FindObjectOfType<KAController>();
        waitBackground = GameObject.FindObjectOfType<WaitBackground>();
        mainScreen = GameObject.FindObjectOfType<MainScreen>();
	}
	

}
