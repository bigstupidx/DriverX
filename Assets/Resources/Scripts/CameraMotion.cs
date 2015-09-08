using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {

    GameObject car;

    float minFieldOfView = 15;
    // Use this for initialization
    void Start () {
        car = GameObject.Find("Car");
        Camera.current.fieldOfView = 15;
    }

    // Update is called once per frame
    void Update () {
        Vector3 carPosition = car.transform.position;
        transform.position = new Vector3(carPosition.x, carPosition.y+70, carPosition.z -60);

        Camera.current.fieldOfView = Mathf.Min(Camera.current.fieldOfView+0.2f, minFieldOfView + car.GetComponent<Move>().GetRelativeSpeed().z/3.7f);
	}
}
