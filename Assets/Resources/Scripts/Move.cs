using UnityEngine;
using System.Collections;
using System;

public class Move : MonoBehaviour {

    public bool isRun = false;

    Rigidbody rigidbody;

    Wheel wheel;

    HingeJoint joint;

    float maxSpeed = 90;

    float acceleration = 1.5f;

    float minSpeedWhenDrift = 20;

    Vector3 relativeSpeed;

    float wheelRotation = 0;
    float deltaWheelRotation = 0.15f;

    float minWheelRotation = -3.5f;
    float maxWheelRotation = 3.5f;
    float maxDriftSpeed = 50;
    float xCompensation = 2.95f;

    Vector3 dir = new Vector3();
    Vector3 lastPos = new Vector3();
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        lastPos = transform.position;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow))
            isRun = true;
        
       if(Input.GetKeyUp(KeyCode.UpArrow))
            isRun = false;


       /*
        if (joint != null)
        {
            float wheelAngle = wheel.GetAngle();

            if (wheelAngle == 0)
            {
                DestroyJoint();
            }
            else
            {
                
                float xAnchor = 160 - Mathf.Abs(wheel.GetAngle());

                if(wheelAngle > 0)
                    xAnchor *= -1;
                

                joint.anchor = new Vector3(xAnchor,0,0);
            }
        }
        else
        {
            if(wheel.GetAngle() != 0)
            {
                CreateJoint();
            }
        }*/
    }
	

	// Update is called once per frame
	void FixedUpdate () {

        dir = (transform.position - lastPos).normalized;
        lastPos = transform.position;
        //    if (isRun)
        //  {

        relativeSpeed = transform.InverseTransformDirection(rigidbody.velocity);
        int znakSpeedX = 1;

        if (relativeSpeed.x < 0)
            znakSpeedX = -1;




        if (Mathf.Abs(relativeSpeed.x) > 0.1f)
        {
            
                float minusSpeedX = Mathf.Min(xCompensation, Mathf.Abs(relativeSpeed.x)) * znakSpeedX * (-1);

                rigidbody.AddRelativeForce(new Vector3(minusSpeedX, 0, 0), ForceMode.VelocityChange);



            /*
            if (relativeSpeed.z > minSpeedWhenDrift)
            {
                Debug.Log("lol");
                float minusSpeedZ = Mathf.Min( Math.Abs(relativeSpeed.z) - minSpeedWhenDrift, 0.5f);

                rigidbody.AddRelativeForce(new Vector3(0, 0, -minusSpeedZ), ForceMode.VelocityChange);
            }*/
                AddGas(maxDriftSpeed);

        }
        else
        {
                AddGas(maxSpeed);          
        }


            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + wheelRotation, 0);
        /*
       }
       else
       {
            
                if (transform.InverseTransformDirection(rigidbody.velocity).z <= 0.2f)
                    rigidbody.velocity = new Vector3(0,0,0);
                else
                    rigidbody.AddRelativeForce(new Vector3(0, 0, -0.5f), ForceMode.VelocityChange);

           


        }
        */




        //   GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0), ForceMode.Force);

    }

    private float MyLerp(float from, float to)
    {
        return 0;
    }

    private void AddGas(float privateMaxSpeed)
    {
        if (relativeSpeed.z < privateMaxSpeed)
        {
            float plusSpeedZ = Mathf.Min(privateMaxSpeed - relativeSpeed.z, acceleration);
            rigidbody.AddRelativeForce(new Vector3(0, 0, plusSpeedZ), ForceMode.VelocityChange);
        }
    }

    void CreateJoint()
    {
       joint = gameObject.AddComponent<HingeJoint>();
       joint.axis = new Vector3(0, 1, 0);
    }

    void DestroyJoint()
    {
        Destroy(GetComponent<HingeJoint>());
    }

    public void PlusWheelRotation()
    {
        wheelRotation = Mathf.Min(wheelRotation + deltaWheelRotation, maxWheelRotation);
    }

    public void MinusWheelRotation()
    {
        wheelRotation = Mathf.Max(wheelRotation - deltaWheelRotation, minWheelRotation);
    }

    public void ToZeroWheelRotation()
    {

        if (wheelRotation < 0)
            wheelRotation = Mathf.Min(0, wheelRotation + 1);

        if (wheelRotation > 0)
            wheelRotation = Mathf.Max(0, wheelRotation - 1);
    }

    public Vector3 GetRelativeSpeed()
    {
        return relativeSpeed;
    }

    public Vector3 GetDirection()
    {
        return dir;
    }
}
