using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
public class CameraMotion : MonoBehaviour
{
    /*
    Camera cam;
    GameObject car;



    void Start()
    {
        car = GameObject.Find("Car");
    }


    void Update()
    {
          Vector3 carPosition = car.transform.position;
        //transform.position = new Vector3(carPosition.x, carPosition.y, carPosition.z);
          transform.position = Vector3.Lerp(transform.position, car.transform.position, Time.deltaTime*10f); //new Vector3(carPosition.x, carPosition.y, carPosition.z);

        //  Debug.Log(transform.position.ToString("F4"));

        transform.rotation = Quaternion.Slerp(transform.rotation, car.transform.rotation, Time.deltaTime*1.8f);
          //car.transform.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
    }
    */


    // The target we are following
    Library library;
    private Camera cam;

    // The distance in the x-z plane to the target
    public float distance = 6.0f;

    // the height we want the camera to be above the target
    public float height = 2.0f;

    private float defaultHeight = 0f;

    public float heightOffset = .75f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    public float minimumFOV = 50f;
    public float maximumFOV = 70f;

    public float maximumTilt = 15f;
    private float tiltAngle = 0f;

    private Vector3 positionVelocity;
    private Quaternion rotationVelocity;


    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();

        // Early out if we don't have a target
        //  if (!playerCar)
        //   {
        //       if (GameObject.FindObjectOfType<RCCCarControllerV2>())
            //else
              //  return;
    //   }

        cam = transform.FindChild("Camera").GetComponent<Camera>();

        ToDefaultPosition();
  //      if (GetComponent<RCCCamManager>())
     //       GetComponent<RCCCamManager>().target = playerCar;

    }
    
    void Update()
    {
        Rigidbody playerRigid = library.car.GetComponent<CarController>().m_Rigidbody;

        tiltAngle = Mathf.Lerp(tiltAngle, (Mathf.Clamp(-library.car.transform.InverseTransformDirection(playerRigid.velocity).x, -35, 35)), Time.deltaTime * 2f);

        cam.fieldOfView = Mathf.Lerp(minimumFOV, maximumFOV, (playerRigid.velocity.magnitude * 3f) / 150f);

    }
    
    void FixedUpdate()
    {

        Rigidbody playerRigid = library.car.GetComponent<CarController>().m_Rigidbody;
        Transform playerCar = library.car.transform;

        float speed = (playerRigid.transform.InverseTransformDirection(playerRigid.velocity).z) * 3f;

        float wantedRotationAngle = playerCar.eulerAngles.y;
        float wantedHeight = playerCar.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        if (speed < -10)
            wantedRotationAngle = playerCar.eulerAngles.y + 180;

        // Damp the rotation around the y-axis

        RaycastHit hit;

        Vector3 temp = transform.position;
        temp.y = temp.y - 1;

        Physics.Raycast(temp, playerCar.position - temp, out hit);



        if (library.globalController.gs == GlobalController.GameState.Ride)
        {
            if (hit.transform != null && hit.transform.GetComponent<CarController>() == null)
            {
                defaultHeight = MathTools.ULerp(defaultHeight, 50, 0.0001f);
            }
            else
                defaultHeight = MathTools.ULerp(defaultHeight, 0, 0.9999f);
        }



        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.fixedDeltaTime );

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.fixedDeltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
          transform.position = playerCar.position;

     

        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight + defaultHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(new Vector3(playerCar.position.x, playerCar.position.y + heightOffset, playerCar.position.z));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(tiltAngle, -10f, 10f));

  
    }

    public void ToDefaultPosition()
    {
        Transform playerCar = library.car.transform;

        transform.rotation = playerCar.rotation;
        transform.position = new Vector3(playerCar.position.x, playerCar.position.y + height *2, playerCar.position.z-distance*2);
    }

}
