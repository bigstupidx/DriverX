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
   [HideInInspector] public TaskStrings taskStrings;
   [HideInInspector] public GameObject pauseButton;
   [HideInInspector] public PauseMenu pauseMenu;
   [HideInInspector] public PreferencesSaver preferencesSaver;
   [HideInInspector] public TaskHelper taskHelper;
   [HideInInspector] public EndMenu endMenu;
   [HideInInspector] public GameObject level;
   [HideInInspector] public GlobalController globalController;
   [HideInInspector] public GameObject cam;
   [HideInInspector] public GameObject metalSparksPrefab;
   [HideInInspector] public WordRideCanvas wordRideCanvas;
   [HideInInspector] public CarUserParametres carUserParametres;
   [HideInInspector] public GameUI gameUI;
   [HideInInspector] public CanvasController canvasController;
   
    // Use this for initialization
    void Start () {
        currentScore = GameObject.Find("CurrentScore").GetComponent<CurrentScore>();
        fullScore = GameObject.Find("FullScore").GetComponent<FullScore>();
        score = GetComponent<Score>();
        energy = GetComponent<Energy>();
        energyLine = GameObject.FindObjectOfType<EnergyLine>();     
        inputController = GameObject.FindObjectOfType<InputController>();
        timerScript = GameObject.FindObjectOfType<TimerScript>();
        timerUI = GameObject.FindObjectOfType<TimerUI>();
        levelInfo = GetComponent<LevelInfo>();
        taskStrings = GetComponent<TaskStrings>();
        pauseButton = GameObject.FindObjectOfType<PauseButton>().gameObject;
        pauseMenu = GameObject.Find("Canvas").GetComponentInChildren<PauseMenu>();
        endMenu = GameObject.Find("Canvas").GetComponentInChildren<EndMenu>();
        preferencesSaver = GetComponent<PreferencesSaver>();
        taskHelper = GameObject.FindObjectOfType<TaskHelper>();
        level = GameObject.FindGameObjectWithTag("Level");
        globalController = GetComponent<GlobalController>();
        cam = GameObject.Find("MainCamera");
        wordRideCanvas = GameObject.FindObjectOfType<WordRideCanvas>();

        metalSparksPrefab = Resources.Load("Prefabs/Particles/MetalSpark") as GameObject;
        carUserParametres = GetComponent<CarUserParametres>();
        gameUI = GameObject.FindObjectOfType<GameUI>();
        canvasController = GameObject.FindObjectOfType<CanvasController>();
    }

}
