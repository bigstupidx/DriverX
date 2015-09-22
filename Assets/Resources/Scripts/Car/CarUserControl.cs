using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private float verticalAxis = 0;
        private float wheelRotation = 0;
        private Library library;

        public float uskorenie = 0.05f;
        public float deltaWheelRotation = 0.05f;

        private void Start()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            library = GameObject.FindObjectOfType<Library>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            verticalAxis = Mathf.Clamp(verticalAxis + uskorenie, 0, 1); //Input.GetAxis("Horizontal");
            //#if !MOBILE_INPUT

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
            

         //   wheelRotation = Input.GetAxis("Horizontal");
           // verticalAxis = Input.GetAxis("Vertical");

            //float handbrake = Input.GetAxis("Jump");
            m_Car.Move(wheelRotation, verticalAxis, verticalAxis, 0);
            //#else
            //      m_Car.Move(h, v, v, 0f);
            //#endif
        }
    }
}
