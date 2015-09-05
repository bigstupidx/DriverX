using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {

    GameObject car;
	// Use this for initialization
	void Start () {
        car = GameObject.Find("Car");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 carPosition = car.transform.position;
        transform.position = new Vector3(carPosition.x, carPosition.y+70, carPosition.z -25);
	}
}
