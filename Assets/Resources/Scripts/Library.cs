using UnityEngine;
using System.Collections;

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
    // Use this for initialization
	void Awake () {
        car = GameObject.Find("Car");
        currentScore = GameObject.Find("CurrentScore").GetComponent<CurrentScore>();
        fullScore = GameObject.Find("FullScore").GetComponent<FullScore>();
        score = GetComponent<Score>();
        energy = GetComponent<Energy>();
        energyLine = GameObject.FindObjectOfType<EnergyLine>();     
        inputController = GameObject.FindObjectOfType<InputController>();
        timerScript = GameObject.FindObjectOfType<TimerScript>();
        timerUI = GameObject.FindObjectOfType<TimerUI>();
        levelInfo = GetComponent<LevelInfo>();
	}
	
}
