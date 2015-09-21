using UnityEngine;
using System.Collections;

public class Library : MonoBehaviour {

    public CurrentScore currentScore;
    public FullScore fullScore;
    public Score score;
    public InputController inputController;
    // Use this for initialization
	void Start () {
        currentScore = GameObject.Find("CurrentScore").GetComponent<CurrentScore>();
        fullScore = GameObject.Find("FullScore").GetComponent<FullScore>();
        score = GetComponent<Score>();
        inputController = GameObject.FindObjectOfType<InputController>();
	}
	
}
