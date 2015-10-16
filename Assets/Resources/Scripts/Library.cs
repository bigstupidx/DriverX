using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class Library : MonoBehaviour {

   [HideInInspector] public GameObject car;
   [HideInInspector] public CurrentScore currentScore;
   [HideInInspector] public FullScore fullScore;
   [HideInInspector] public Score score;
   [HideInInspector] public Energy energy;
   [HideInInspector] public EnergyLine energyLine;
   [HideInInspector] public InputController inputController;
   [HideInInspector] public TimerScript timerScript;
   [HideInInspector] public TimerUI timerUI;
   [HideInInspector] public LevelInfo levelInfo;
   [HideInInspector] public GameObject tasks;
   [HideInInspector] public TaskStrings taskStrings;
   [HideInInspector] public GameObject pauseButton;
   [HideInInspector] public GameObject pauseMenu;
   [HideInInspector] public PreferencesSaver preferencesSaver;
   [HideInInspector] public TaskHelper taskHelper;
    // Use this for initialization
    void Awake () {
        car = GameObject.FindObjectOfType<CarController>().gameObject;
        currentScore = GameObject.Find("CurrentScore").GetComponent<CurrentScore>();
        fullScore = GameObject.Find("FullScore").GetComponent<FullScore>();
        score = GetComponent<Score>();
        energy = GetComponent<Energy>();
        energyLine = GameObject.FindObjectOfType<EnergyLine>();     
        inputController = GameObject.FindObjectOfType<InputController>();
        timerScript = GameObject.FindObjectOfType<TimerScript>();
        timerUI = GameObject.FindObjectOfType<TimerUI>();
        levelInfo = GetComponent<LevelInfo>();
        tasks = GameObject.Find("Tasks");
        taskStrings = GetComponent<TaskStrings>();
        pauseButton = GameObject.FindObjectOfType<PauseButton>().gameObject;
        pauseMenu = GameObject.Find("Canvas").transform.FindChild("Scroll").gameObject;
        preferencesSaver = GetComponent<PreferencesSaver>();
        taskHelper = GameObject.FindObjectOfType<TaskHelper>();
	}
	
}
