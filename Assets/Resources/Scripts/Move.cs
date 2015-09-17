using UnityEngine;

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
    float deltaWheelRotation = 0.075f;

    float maxWheelRotation = 1.5f;
    float maxDriftSpeed = 80;
    float xCompensationCoef = 0.03447815f/2f;
    float tresholdSpeedX;

    float compensationOnLowTurn = 8;

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
            tresholdSpeedX = 0.726183f / 2* maxWheelRotation * maxDriftSpeed-3 ;
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
        relativeSpeed = transform.InverseTransformDirection(rigidbody.velocity);

        int znakSpeedX = 1;

        if (relativeSpeed.x < 0)
            znakSpeedX = -1;

       
            if (Mathf.Abs(relativeSpeed.x) > 0.001)
            {
                if (Mathf.Abs(wheelRotation) >= maxWheelRotation - 0.5f) // если занос
                {
                    AddGas(maxDriftSpeed);
                    float minusSpeedX;

                    if (Mathf.Abs(relativeSpeed.x) < tresholdSpeedX && wheelRotation != 0)
                        minusSpeedX = 0;
                    else
                        minusSpeedX = Mathf.Min(xCompensation, Mathf.Abs(relativeSpeed.x));

                    rigidbody.AddRelativeForce(new Vector3(minusSpeedX * znakSpeedX * (-1), 0, 0), ForceMode.VelocityChange);
                }
                else
                {
                    AddGas(maxSpeed);
                float minusSpeedX;

                minusSpeedX = Mathf.Min(compensationOnLowTurn, Mathf.Abs(relativeSpeed.x));

                rigidbody.AddRelativeForce(new Vector3(minusSpeedX * znakSpeedX * (-1), 0, 0), ForceMode.VelocityChange);


            }
        }
            else
            {
                AddGas(maxSpeed);
            }
        
        


       
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
        wheelRotation = Mathf.Max(wheelRotation - deltaWheelRotation, -maxWheelRotation);
    }

    public void ToZeroWheelRotation()
    {

        if (wheelRotation < 0)
            wheelRotation = Mathf.Min(0, wheelRotation + 0.1f);

        if (wheelRotation > 0)
            wheelRotation = Mathf.Max(0, wheelRotation - 0.1f);

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
