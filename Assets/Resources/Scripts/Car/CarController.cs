using System;
using UnityEngine;


internal enum CarDriveType
{
    FrontWheelDrive,
    RearWheelDrive,
    FourWheelDrive
}

internal enum SpeedType
{
    MPH,
    KPH
}

public class CarController : MonoBehaviour
{
    [SerializeField] private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;
    [SerializeField] private WheelCollider[] m_WheelColliders = new WheelCollider[4];
    [SerializeField] private GameObject[] m_WheelMeshes = new GameObject[4];
    [SerializeField] private WheelEffects[] m_WheelEffects = new WheelEffects[4];
    [SerializeField] private Vector3 m_CentreOfMassOffset;
    [SerializeField] private float m_MaximumSteerAngle;
    [SerializeField]
     private float m_SteerHelper = 0.98f; // 0 is raw physics , 1 the car will grip in the direction it is facing
    [SerializeField]
    private float m_TractionControl = 0.9f; // 0 is no traction control, 1 is full interference
    [SerializeField] private float m_FullTorqueOverAllWheels;
    [SerializeField] private float m_ReverseTorque;
    [SerializeField] private float m_MaxHandbrakeTorque;
    [SerializeField] private float m_Downforce = 100f;
    [SerializeField] private SpeedType m_SpeedType;
    private float m_Topspeed = 55;
    [SerializeField] private static int NoOfGears = 5;
    [SerializeField] private float m_RevRangeBoundary = 1f;
    [SerializeField] private float m_SlipLimit;
    [SerializeField] private float m_BrakeTorque;

       
    private Quaternion[] m_WheelMeshLocalRotations;
    private Vector3 m_Prevpos, m_Pos;
    private float m_SteerAngle;
    private int m_GearNum;
    private float m_GearFactor;
    private float m_OldRotation;
    private float m_CurrentTorque;
    [SerializeField] public Rigidbody m_Rigidbody;
    private const float k_ReversingThreshold = 0.01f;

    public bool Skidding { get; private set; }
    public float BrakeInput { get; private set; }
    public float CurrentSteerAngle{ get { return m_SteerAngle; }}
    public float CurrentSpeed{ get { return m_Rigidbody.velocity.magnitude*2.23693629f; }}
    public float MaxSpeed{get { return m_Topspeed; }}
    public float Revs { get; private set; }
    public float AccelInput { get; private set; }

    float maxAngleX = 30;
    float maxAngleZ = 30;

    private Particle rideEffect;

    private CarContact carContact;

    int nitroMnozitel = 100;

    //  public float dustAngle;

    private int numNitro = 35;
    private int currentNitro = 0;

    Transform asotSystems;
    ParticleSystem[] rayAsot;

    Library library;

    [HideInInspector] public float nMaxSpeed = 85;
    [HideInInspector] public float nMinSpeed = 65;

    Poddon poddon;

    bool wasNitro;

    float firstTimer;
    // Use this for initialization
    void Awake()
    {
        library = GameObject.FindObjectOfType<Library>();

        m_WheelMeshLocalRotations = new Quaternion[4];
        for (int i = 0; i < 4; i++)
        {
            m_WheelMeshLocalRotations[i] = m_WheelMeshes[i].transform.localRotation;
        }
        m_WheelColliders[0].attachedRigidbody.centerOfMass = m_CentreOfMassOffset;

        m_MaxHandbrakeTorque = float.MaxValue;

        m_Rigidbody = GetComponent<Rigidbody>();
        m_CurrentTorque = m_FullTorqueOverAllWheels - (m_TractionControl*m_FullTorqueOverAllWheels);

        rideEffect = transform.FindChild("Particles").FindChild("RideEffect").GetComponent<Particle>();

        asotSystems = transform.FindChild("Particles").FindChild("AsotSystems");


        UpdateMaxSpeed();

        rayAsot = transform.FindChild("Particles").FindChild("RayAsot").GetComponentsInChildren<ParticleSystem>();
        carContact = GetComponent<CarContact>();


        poddon = GameObject.FindObjectOfType<Poddon>();

    }

    void Start()
    {
        ToStartPosition();

    }
    void Update()
    {
        float newAngleX = GetClamAngle(transform.eulerAngles.x, maxAngleX);
        float newAngleZ = GetClamAngle(transform.eulerAngles.z, maxAngleZ);

    //    newAngleX = MathTools.ULerp(transform.eulerAngles.x, maxAngleX, Mathf.Abs(m_Rigidbody.angularVelocity.x)* Time.deltaTime);

        transform.rotation = Quaternion.Euler(newAngleX, transform.rotation.eulerAngles.y, newAngleZ);

        if(currentNitro > 0)
        {
            firstTimer += Time.deltaTime;

            float preVal = firstTimer * nitroMnozitel;

            int val = (int)Mathf.Floor(preVal);

            firstTimer = (preVal - val) / nitroMnozitel;
        
            library.score.AddScore(val);
        }
        else
        {
            firstTimer = 0;
        }

    }

    float GetClamAngle(float currentAngle, float maxAngle)
    {
        float newAngle = currentAngle;

        if (currentAngle > maxAngle && currentAngle <= 180)
            newAngle = maxAngle;
        else
            if (currentAngle > 180 && currentAngle < 360 - maxAngle)
            newAngle = 360 - maxAngle;
        return newAngle;
    }

    private void GearChanging()
    {
        float f = Mathf.Abs(CurrentSpeed/MaxSpeed);
        float upgearlimit = (1/(float) NoOfGears)*(m_GearNum + 1);
        float downgearlimit = (1/(float) NoOfGears)*m_GearNum;

        if (m_GearNum > 0 && f < downgearlimit)
        {
            m_GearNum--;
        }

        if (f > upgearlimit && (m_GearNum < (NoOfGears - 1)))
        {
            m_GearNum++;
        }
    }


    // simple function to add a curved bias towards 1 for a value in the 0-1 range
    private static float CurveFactor(float factor)
    {
        return 1 - (1 - factor)*(1 - factor);
    }


    // unclamped version of Lerp, to allow value to exceed the from-to range
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value)*from + value*to;
    }


    private void CalculateGearFactor()
    {
        float f = (1/(float) NoOfGears);
        // gear factor is a normalised representation of the current speed within the current gear's range of speeds.
        // We smooth towards the 'target' gear factor, so that revs don't instantly snap up or down when changing gear.
        var targetGearFactor = Mathf.InverseLerp(f*m_GearNum, f*(m_GearNum + 1), Mathf.Abs(CurrentSpeed/MaxSpeed));
        m_GearFactor = Mathf.Lerp(m_GearFactor, targetGearFactor, Time.deltaTime*5f);
    }


    private void CalculateRevs()
    {
        // calculate engine revs (for display / sound)
        // (this is done in retrospect - revs are not used in force/power calculations)
        CalculateGearFactor();
        var gearNumFactor = m_GearNum/(float) NoOfGears;
        var revsRangeMin = ULerp(0f, m_RevRangeBoundary, CurveFactor(gearNumFactor));
        var revsRangeMax = ULerp(m_RevRangeBoundary, 1f, gearNumFactor);
        Revs = ULerp(revsRangeMin, revsRangeMax, m_GearFactor);
    }


    public void Move(float steering, float accel, float footbrake, float handbrake)
    {
        
        if(poddon.IsZavis()/* && carContact.IsFreeAllWheel()*/)
        {
            if(accel > 0)
            {
                m_Rigidbody.AddRelativeForce(new Vector3(0, 0,15000), ForceMode.Force);
            }
            else
            {
                m_Rigidbody.AddRelativeForce(new Vector3(0, 0, -15000), ForceMode.Force);

            }
        }

        UpdateWheelPosition();

       
        //clamp input values
        steering = Mathf.Clamp(steering, -1, 1);
        AccelInput = accel = Mathf.Clamp(accel, 0, 1);
        BrakeInput = footbrake = -1*Mathf.Clamp(footbrake, -1, 0);
        handbrake = Mathf.Clamp(handbrake, 0, 1);

        //Set the steer on the front wheels.
        //Assuming that wheels 0 and 1 are the front wheels.
        m_SteerAngle = steering *
            (1 - ((library.carUserParametres.controllability - library.carUserParametres.speed) * 0.1f + (CurrentSpeed * 0.55f) / MaxSpeed)) * m_MaximumSteerAngle;
        m_WheelColliders[0].steerAngle = m_SteerAngle;
        m_WheelColliders[1].steerAngle = m_SteerAngle;

        SteerHelper();
        ApplyDrive(accel, footbrake);
        CapSpeed();


        //Set the handbrake.
        //Assuming that wheels 2 and 3 are the rear wheels.
        if (handbrake > 0f)
        {
            var hbTorque = handbrake*m_MaxHandbrakeTorque;
            m_WheelColliders[2].brakeTorque = hbTorque;
            m_WheelColliders[3].brakeTorque = hbTorque;
        }


        CalculateRevs();
        GearChanging();

        AddDownForce();
        CheckForWheelSpin();
        TractionControl();

        if(currentNitro > 0)
        {
            m_Rigidbody.AddRelativeForce(new Vector3(0, 0, 70000), ForceMode.Force);
            currentNitro--;
        }

    }

    void UpdateWheelPosition()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 position;
            m_WheelColliders[i].GetWorldPose(out position, out quat);
            m_WheelMeshes[i].transform.position = position;
            m_WheelMeshes[i].transform.rotation = quat;


        }


    }

    private void CapSpeed()
    {
        float speed = m_Rigidbody.velocity.magnitude;
    

        speed *= 2.23693629f;



        if (speed > m_Topspeed)
        {
            if (currentNitro <= 0)
            {
                if (wasNitro)
                    m_Rigidbody.velocity = Vector3.Lerp(m_Rigidbody.velocity, ((m_Topspeed - 15) / 2.23693629f) * m_Rigidbody.velocity.normalized, 0.08f); // m_Topspeed - 10  ����� ������� ���������
                else
                {
                    m_Rigidbody.velocity = (m_Topspeed / 2.23693629f) * m_Rigidbody.velocity.normalized;
                }
            }
        }//  m_Rigidbody.velocity = m_Topspeed/2.23693629f *m_Rigidbody.velocity.normalized;
        else
        {
            if (wasNitro && currentNitro <= 0)
                wasNitro = false;
        }
       
    }


    private void ApplyDrive(float accel, float footbrake)
    {

        float thrustTorque;
        switch (m_CarDriveType)
        {
            case CarDriveType.FourWheelDrive:
                thrustTorque = accel * (m_CurrentTorque / 4f);
                for (int i = 0; i < 4; i++)
                {
                    m_WheelColliders[i].motorTorque = thrustTorque;
                }
                break;

            case CarDriveType.FrontWheelDrive:
                thrustTorque = accel * (m_CurrentTorque / 2f);
                m_WheelColliders[0].motorTorque = m_WheelColliders[1].motorTorque = thrustTorque;
                break;

            case CarDriveType.RearWheelDrive:
                thrustTorque = accel * (m_CurrentTorque / 2f);
                m_WheelColliders[2].motorTorque = m_WheelColliders[3].motorTorque = thrustTorque;
                break;

        }
        
        for (int i = 0; i < 4; i++)
        {
            if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
            {
                m_WheelColliders[i].brakeTorque = m_BrakeTorque*footbrake;
            }
            else if (footbrake > 0)
            {
                m_WheelColliders[i].brakeTorque = 0f;
                m_WheelColliders[i].motorTorque = -m_ReverseTorque*footbrake;
            }
        }
    }


    private void SteerHelper()
    {
        for (int i = 0; i < 4; i++)
        {
            WheelHit wheelhit;
            m_WheelColliders[i].GetGroundHit(out wheelhit);
            if (wheelhit.normal == Vector3.zero)
                return; // wheels arent on the ground so dont realign the rigidbody velocity
        }

        // this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
        if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
        {
            var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
            Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
            m_Rigidbody.velocity = velRotation * m_Rigidbody.velocity;
        }
        m_OldRotation = transform.eulerAngles.y;
    }


    // this is used to add more grip in relation to speed
    private void AddDownForce()
    {
        m_WheelColliders[0].attachedRigidbody.AddForce(-transform.up*m_Downforce*
                                                        m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
            
    }


    // checks if the wheels are spinning and is so does three things
    // 1) emits particles
    // 2) plays tiure skidding sounds
    // 3) leaves skidmarks on the ground
    // these effects are controlled through the WheelEffects class
    private void CheckForWheelSpin()
    {
        // loop through all wheels

        bool allWheelHit = true;
        int col = 2;
        for (int i = 0; i < 4; i++)
        {
            // WheelHit wheelHit;
            //  m_WheelColliders[i].GetGroundHit(out wheelHit);
            if(!m_WheelColliders[i].isGrounded)
                col--;

            if (col <0)
            {
                allWheelHit = false;
                break;
            }

            
           m_WheelColliders[i].GetComponent<Probuksovka>().ProbuksovkaEmit();

            //  m_WheelColliders[i].GetComponent<Probuksovka>().RideEffectEmit();
        }
        
        if (allWheelHit)
        {
            ParticleSystem particleSystem = rideEffect.GetParticle();
            Quaternion quater = Quaternion.LookRotation(m_Rigidbody.velocity.normalized);
            quater *= Quaternion.Euler(0, 180, 0);
            particleSystem.transform.rotation = Quaternion.Slerp(particleSystem.transform.rotation, quater, Time.deltaTime * 5);

            TwoColor twoColor = particleSystem.GetComponent<TwoColor>();
            Color color = particleSystem.startColor;

            if (twoColor != null)
            {
                
                if (UnityEngine.Random.Range(1, 3) == 1)
                    color = twoColor.color1;
                else
                    color = twoColor.color2;
            }

            color.a = color.a * CurrentSpeed / MaxSpeed;
            particleSystem.startColor = color;

            if (!particleSystem.loop)
                rideEffect.PlayLoop();

        }
        else
        {
            rideEffect.StopLoop();
        }
        

        // is the tire slipping above the given threshhold
        // if (Mathf.Abs(wheelHit.forwardSlip) >= m_SlipLimit || Mathf.Abs(wheelHit.sidewaysSlip) >= m_SlipLimit)
        //  {
        //      m_WheelEffects[i].EmitTyreSmoke();

        // avoiding all four tires screeching at the same time
        // if they do it can lead to some strange audio artefacts
        /*
        if (!AnySkidSoundPlaying())
        {
            m_WheelEffects[i].PlayAudio();
        }
//         continue;*/
        //     }
        /*
        // if it wasnt slipping stop all the audio
        if (m_WheelEffects[i].PlayingAudio)
        {
            m_WheelEffects[i].StopAudio();
        }
        // end the trail generation*/
        // m_WheelEffects[i].EndSkidTrail();
        //}
    }

    // crude traction control that reduces the power to wheel if the car is wheel spinning too much
    private void TractionControl()
    {
        WheelHit wheelHit;
        switch (m_CarDriveType)
        {
            case CarDriveType.FourWheelDrive:
                // loop through all wheels
                for (int i = 0; i < 4; i++)
                {
                    m_WheelColliders[i].GetGroundHit(out wheelHit);

                    AdjustTorque(wheelHit.forwardSlip);
                }
                break;

            case CarDriveType.RearWheelDrive:
                m_WheelColliders[2].GetGroundHit(out wheelHit);
                AdjustTorque(wheelHit.forwardSlip);

                m_WheelColliders[3].GetGroundHit(out wheelHit);
                AdjustTorque(wheelHit.forwardSlip);
                break;

            case CarDriveType.FrontWheelDrive:
                m_WheelColliders[0].GetGroundHit(out wheelHit);
                AdjustTorque(wheelHit.forwardSlip);

                m_WheelColliders[1].GetGroundHit(out wheelHit);
                AdjustTorque(wheelHit.forwardSlip);
                break;
        }
    }


    private void AdjustTorque(float forwardSlip)
    {
        if (forwardSlip >= m_SlipLimit && m_CurrentTorque >= 0)
        {
            m_CurrentTorque -= 10 * m_TractionControl;
        }
        else
        {
            m_CurrentTorque += 10 * m_TractionControl;
            if (m_CurrentTorque > m_FullTorqueOverAllWheels)
            {
                m_CurrentTorque = m_FullTorqueOverAllWheels;
            }
        }
    }


    private bool AnySkidSoundPlaying()
    {
        for (int i = 0; i < 4; i++)
        {
            if (m_WheelEffects[i].PlayingAudio)
            {
                return true;
            }
        }
        return false;
    }


    public void Nitro()
    {

        if (library.energy.EnergyEnough())
        {
            StartCoroutine(ShowNitro());

            library.energy.UseEnergy();

            library.score.AddCoef();

            foreach (Transform asotSystem in asotSystems)
            {
                asotSystem.GetComponent<ParticleSystem>().Play();
            }
        }
            
    }

    System.Collections.IEnumerator ShowNitro()
    {
        yield return new WaitForSeconds(0.1f);

        rayAsot[0].Play();

        currentNitro = numNitro;
        wasNitro = true;
    }

    public bool IsNitro()
    {
       // Debug.Log("CurrentSpeed " + CurrentSpeed+"; MaxSpeed "+ MaxSpeed);

        if (CurrentSpeed >= MaxSpeed + 20 || currentNitro > 0)
            return true;
        else
            return false;
    }

    public WheelCollider[] GetWheelColliders()
    {
        return m_WheelColliders;
    }

    public void ToStartPosition()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);

        //    m_Rigidbody.velocity = new Vector3(0, 0, 0);

        for (int i = 0; i < 4; i++)
        {
            m_WheelColliders[i].gameObject.SetActive(false);
            m_WheelColliders[i].gameObject.SetActive(true);
        }

        UpdateWheelPosition();

        Transform startPosition = library.level.transform.FindChild("StartPosition").transform;
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;

        library.cam.GetComponent<CameraMotion>().ToDefaultPosition();
    }

    public void MoveBack(float wheelRotation, float verticalAxis)
    {
        float zSpeed = transform.InverseTransformDirection(m_Rigidbody.velocity).z;



        if (carContact.IsOneContact() && zSpeed > -20)
        {
            m_Rigidbody.AddRelativeForce(new Vector3(0, 0, -9000), ForceMode.Force);
        }

        Move(wheelRotation, verticalAxis, verticalAxis, 0);
    }

    public void UpdateMaxSpeed()
    {
        m_Topspeed += (3 + (library.carUserParametres.speed - library.carUserParametres.minSpeed) * 2) / (float)CarUserParametres.maxVal * (nMaxSpeed - nMinSpeed);
    }

}

