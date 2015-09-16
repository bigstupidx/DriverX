using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour
{
    Camera cam;
    GameObject car;



    void Start()
    {
        car = GameObject.Find("Car");
    }


    void Update()
    {
          Vector3 carPosition = car.transform.position;
          transform.position = new Vector3(carPosition.x, carPosition.y, carPosition.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, car.transform.rotation, Time.deltaTime*4);
          //car.transform.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
    }

}
