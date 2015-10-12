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
    public Transform playerCar;
    private Rigidbody playerRigid;
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

        // Early out if we don't have a target
        //  if (!playerCar)
        //   {
        //       if (GameObject.FindObjectOfType<RCCCarControllerV2>())
        playerCar = GameObject.FindObjectOfType<CarController>().transform;
            //else
              //  return;
    //   }

        playerRigid = playerCar.GetComponent<Rigidbody>();
        cam = transform.FindChild("Camera").GetComponent<Camera>();

  //      if (GetComponent<RCCCamManager>())
     //       GetComponent<RCCCamManager>().target = playerCar;

    }

    void Update()
    {

        // Early out if we don't have a target
//        if (!playerCar)
   //         return;

   //     if (playerRigid != playerCar.GetComponent<Rigidbody>())
   //         playerRigid = playerCar.GetComponent<Rigidbody>();

        //Tilt Angle Calculation.
        tiltAngle = Mathf.Lerp(tiltAngle, (Mathf.Clamp(-playerCar.InverseTransformDirection(playerRigid.velocity).x, -35, 35)), Time.deltaTime * 2f);

       // if (!cam)
   //         cam = GetComponent<Camera>();

        cam.fieldOfView = Mathf.Lerp(minimumFOV, maximumFOV, (playerRigid.velocity.magnitude * 3f) / 150f);

    }

    void FixedUpdate()
    {
        // Early out if we don't have a target
      //  if (!playerCar || !playerRigid)
    //        return;

        float speed = (playerRigid.transform.InverseTransformDirection(playerRigid.velocity).z) * 3f;

        // Calculate the current rotation angles.
        float wantedRotationAngle = playerCar.eulerAngles.y;
        float wantedHeight = playerCar.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        if (speed < -2)
            wantedRotationAngle = playerCar.eulerAngles.y + 180;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

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

    /*    float positionSmooth = 40;
        float rotationSmooth = 40;

        Quaternion targetRotation = Quaternion.LookRotation(playerCar.transform.position - transform.position);
        Quaternion lookAtRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        float newXPosition = Mathf.SmoothDamp(transform.position.x, playerCar.position.x, ref positionVelocity.x, positionSmooth / 100);
        float newYPosition = Mathf.SmoothDamp(transform.position.y, playerCar.position.y, ref positionVelocity.y, positionSmooth / 100);
        float newZPosition = Mathf.SmoothDamp(transform.position.z, playerCar.position.z, ref positionVelocity.z, positionSmooth / 100);
        transform.position = new Vector3(newXPosition, newYPosition, newZPosition);
  //      float newXRotation = Mathf.SmoothDampAngle(transform.rotation.x, playerCar.rotation.x, ref rotationVelocity.x, rotationSmooth / 100);
  //      float newYRotation = Mathf.SmoothDampAngle(transform.rotation.y, playerCar.rotation.y, ref rotationVelocity.y, rotationSmooth / 100);
   //     float newZRotation = Mathf.SmoothDampAngle(transform.rotation.z, playerCar.rotation.z, ref rotationVelocity.z, rotationSmooth / 100);
   //     float newWRotation = Mathf.SmoothDampAngle(transform.rotation.w, playerCar.rotation.w, ref rotationVelocity.w, rotationSmooth / 100);
   //     transform.rotation = new Quaternion(newXRotation + lookAtRotation.x, newYRotation + lookAtRotation.y, newZRotation + lookAtRotation.z, newWRotation + lookAtRotation.w);

    */
    }



}
