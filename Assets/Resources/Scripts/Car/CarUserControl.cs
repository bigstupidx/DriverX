using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class CarUserControl : MonoBehaviour
{
        
    private CarController m_Car; // the car controller we want to use
    private float verticalAxis = 0;
    private float wheelRotation = 0;
    private float handbrake = 0;
    private Library library;

    private float uskorenie = 0.5f;
    private float deltaWheelRotation = 0.1f;
    private float deltaHandbrake = 0.1f;

    bool isEnd;
    bool isStay;

    private void Start()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
        library = GameObject.FindObjectOfType<Library>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car!
        //#if !MOBILE_INPUT
        if (!isEnd)
        {
            InputController.Direction directionWheel = library.inputController.GetDirection();

            switch (directionWheel)
            {
                case InputController.Direction.LEFT:
                    wheelRotation = Mathf.Clamp(wheelRotation - deltaWheelRotation, -1, 1);
                    break;
                case InputController.Direction.RIGHT:
                    wheelRotation = Mathf.Clamp(wheelRotation + deltaWheelRotation, -1, 1);
                    break;
                case InputController.Direction.NONE:
                    if (wheelRotation < 0)
                        wheelRotation = Mathf.Clamp(wheelRotation + deltaWheelRotation, -1, 0);
                    else if (wheelRotation > 0)
                        wheelRotation = Mathf.Clamp(wheelRotation - deltaWheelRotation, 0, 1);
                    break;
            }


            if (Input.GetKey(KeyCode.A) || library.inputController.HandbrakeIsUse())
            {
                verticalAxis = Mathf.Clamp(verticalAxis - uskorenie, -1, 1);
                m_Car.MoveBack(wheelRotation, verticalAxis);
            }
            else
            {
                verticalAxis = Mathf.Clamp(verticalAxis + uskorenie, -1, 1);
                m_Car.Move(wheelRotation, verticalAxis, verticalAxis, 0);
            }
        
           

       
        }
        else
        {
            if (!m_Car.GetComponent<CarContact>().IsFlight())
            {
                if (GetComponent<Rigidbody>().velocity.magnitude < 1)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    isStay = true;
                }
                else
                {
                    m_Car.Move(0, 0, 0, 1);
                    m_Car.GetComponent<Rigidbody>().velocity = Vector3.Lerp(m_Car.GetComponent<Rigidbody>().velocity, Vector3.zero, 0.02f);
                }
            }
        }
    }

    void Update()
    {
        if(!isEnd)
            if (Input.GetKeyDown(KeyCode.Q)|| library.inputController.NitroIsUsed())
                m_Car.Nitro();
    }

    public bool IsStay()
    {
        return isStay;
    }

   

    public void ToDefault()
    {
        isStay = false;
        isEnd = false;
    }

    public void SetEnd()
    {
        isEnd = true;
    }
  
}
