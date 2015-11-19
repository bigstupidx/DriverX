using UnityEngine;
using System.Collections;

public class CarUserParametres : MonoBehaviour {

    public static int maxVal = 9;
    [Range(1, 9)] public int controllability;
    [Range(1, 9)] public int nitro;
    [Range(1, 9)] public int speed;

    // Use this for initialization
    void Start () {
        controllability = Mathf.Clamp(controllability, 1, maxVal);
        nitro = Mathf.Clamp(nitro, 1, maxVal);
        speed = Mathf.Clamp(speed, 1, maxVal);
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
