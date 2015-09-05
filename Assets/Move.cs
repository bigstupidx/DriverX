using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public bool isRun = false;

    Rigidbody rigidbody;

    Wheel wheel;

    HingeJoint joint;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        wheel = GameObject.Find("Canvas/Wheel").GetComponent<Wheel>();
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
        
        if (isRun)
        {


            if (transform.InverseTransformDirection(rigidbody.velocity).z <= 25)
            rigidbody.AddRelativeForce(new Vector3(0, 0, 1f), ForceMode.VelocityChange);



            rigidbody.AddRelativeForce(new Vector3(transform.InverseTransformDirection(rigidbody.velocity).x * (-1f), 0, 0), ForceMode.VelocityChange);

            float deltaAngle = wheel.GetAngle()/30*(-1);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y +deltaAngle, 0);

        }
        else
        {
            
                if (transform.InverseTransformDirection(rigidbody.velocity).z <= 0.2f)
                    rigidbody.velocity = new Vector3(0,0,0);
                else
                    rigidbody.AddRelativeForce(new Vector3(0, 0, -0.5f), ForceMode.VelocityChange);

           


        }





        //   GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0), ForceMode.Force);

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




}
