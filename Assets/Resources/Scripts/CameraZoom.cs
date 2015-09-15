using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    Camera cam;
    GameObject car;

    float min;

    float temp;
    // Use this for initialization
    float speedZoom = 45;
    float distaceCoef = 1 / 2.5f;

    void Start()
    {
        car = GameObject.Find("Car");
        min = transform.localPosition.z;
        temp = min;

    }

    // Update is called once per frame
    void Update()
    {
        //     Vector3 carPosition = car.transform.position;
        //  transform.position = new Vector3(carPosition.x, carPosition.y+80, carPosition.z -40);

        temp = transform.localPosition.z;

        float newFieldOfView = min - car.GetComponent<Move>().GetRelativeSpeed().z * distaceCoef;

        // float delta = Mathf.Min(0.1f, Mathf.Abs(tempFieldOfView - newFieldOfView));
        float delta = Time.deltaTime * speedZoom;

        //      Debug.Log(Mathf.Abs(temp - newFieldOfView));

        if (Mathf.Abs(temp - newFieldOfView) > 0.1f)
        //          delta = 0;
        {
            Debug.Log(Mathf.Abs(temp - newFieldOfView));

            transform.Translate(0, 0, -delta * MathTools.GetZnak(temp - newFieldOfView));
        }
    }
}
