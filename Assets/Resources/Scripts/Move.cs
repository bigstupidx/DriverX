using UnityEngine;
using System.Collections;
using System;

public class Move : MonoBehaviour {

    public bool isRun = false;

    Rigidbody rigidbody;

    Wheel wheel;

    HingeJoint joint;

    float maxSpeed = 100;

    float acceleration = 1.5f;

    float minSpeedWhenDrift = 20;

    Vector3 relativeSpeed;

    float wheelRotation = 0;
    float deltaWheelRotation = 0.15f;

    float minWheelRotation = -2f;
    float maxWheelRotation = 2f;
    float maxDriftSpeed = 60;
    float xCompensationCoef = 0.03447815f/2f;
    float tresholdSpeedX;

    //0.03496f
    float xCompensation;
    Vector3 dir = new Vector3();
    Vector3 lastPos = new Vector3();
	// Use this for initialization
	void Start () {
        xCompensation = xCompensationCoef * maxDriftSpeed  * maxWheelRotation;

        rigidbody = GetComponent<Rigidbody>();
        lastPos = transform.position;

        if (maxDriftSpeed <= 60)
            tresholdSpeedX = 0.726183f * maxDriftSpeed-3 ;
        else
            tresholdSpeedX = 44f-3;
    }

    void Update()
    {


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
    void FixedUpdate() {

        UpdateDirection();

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + wheelRotation, 0);
        //rigidbody.AddRelativeTorque(0, wheelRotation/50, 0, ForceMode.VelocityChange);
        relativeSpeed = transform.InverseTransformDirection(rigidbody.velocity);

        int znakSpeedX = 1;

        if (relativeSpeed.x < 0)
            znakSpeedX = -1;

        Debug.Log(relativeSpeed.ToString("F7"));
        if (Mathf.Abs(relativeSpeed.x) > 0.001)
        {
         //   float tresholdSpeedX;
         //   if (maxDriftSpeed <= 60)
         //       tresholdSpeedX = 0.726183f*maxDriftSpeed;
            //  if (Mathf.Abs(relativeSpeed.x) > 44 && Mathf.Abs(relativeSpeed.x) < 46)
            //  {
         //   if (relativeSpeed.z < maxDriftSpeed)
      //      {
                AddGas(maxDriftSpeed);

                //}

                float minusSpeedX;
            //  if (Mathf.Abs(relativeSpeed.x) > 44 && Mathf.Abs(relativeSpeed.x) < 46)
         //   Debug.Log(tresholdSpeedX);
            if (Mathf.Abs(relativeSpeed.x) < tresholdSpeedX && wheelRotation != 0)
            {
                //Debug.Log("LOL "+Mathf.Abs(relativeSpeed.x - tresholdSpeedX));
            //    if (Mathf.Abs(relativeSpeed.x) - tresholdSpeedX < xCompensation)
         //       {
        //            minusSpeedX = (Mathf.Abs(relativeSpeed.x) - tresholdSpeedX)*(-1);

       //             Debug.Log("LOL " + (Mathf.Abs(relativeSpeed.x)- tresholdSpeedX));
       //         }
       //         else
                    minusSpeedX = -2;
            }
            else
                minusSpeedX = Mathf.Min(xCompensation, Mathf.Abs(relativeSpeed.x)); /* *znakSpeedX* (-1)*/ ;
                //     else
                //      minusSpeedX = 1;
              //  Debug.Log("MinusSpeedX " + minusSpeedX);
                rigidbody.AddRelativeForce(new Vector3(minusSpeedX * znakSpeedX * (-1), 0, 0), ForceMode.VelocityChange);

         //   }//   AddGas(maxDriftSpeed);
            /*
            if (relativeSpeed.z > maxDriftSpeed)
            {
                float plusSpeedZ = Mathf.Min(relativeSpeed.z - maxDriftSpeed, 1);
                rigidbody.AddRelativeForce(new Vector3(0, 0, -plusSpeedZ), ForceMode.VelocityChange);
            }*/
            //      float minusSpeedX;
            // if (Mathf.Abs(relativeSpeed.x) > 44 && Mathf.Abs(relativeSpeed.x) < 46)
            //         minusSpeedX = Mathf.Min(xCompensation, Mathf.Abs(relativeSpeed.x)) /* *znakSpeedX* (-1)*/ ;
            //    else
            //      minusSpeedX = 1;

            //     rigidbody.AddRelativeForce(new Vector3(minusSpeedX * znakSpeedX* (-1), 0, 0), ForceMode.VelocityChange);



            /*
            if (relativeSpeed.z > minSpeedWhenDrift)
            {
                Debug.Log("lol");
                float minusSpeedZ = Mathf.Min( Math.Abs(relativeSpeed.z) - minSpeedWhenDrift, 0.5f);

                rigidbody.AddRelativeForce(new Vector3(0, 0, -minusSpeedZ), ForceMode.VelocityChange);
            }*/

        }
        else
        {
                AddGas(maxSpeed);          
        }


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

    private void UpdateDirection()
    {
        dir = (transform.position - lastPos).normalized;
        lastPos = transform.position;
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
            wheelRotation = Mathf.Min(0, wheelRotation + 0.3f);

        if (wheelRotation > 0)
            wheelRotation = Mathf.Max(0, wheelRotation - 0.3f);

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
