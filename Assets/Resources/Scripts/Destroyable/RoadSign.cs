using UnityEngine;
using System.Collections;

public class RoadSign : Destroyable
{

    bool isProcess;
    Quaternion quater;
    public override void OnCollision(Transform carTransform)
    {
        Vector3 dir = Vector3.Reflect(carTransform.GetComponent<CarContact>().GetDirection(), Vector3.up);

        Destroy(GetComponent<Collider>());

        isProcess = true;

         quater = Quaternion.AngleAxis(90, Vector3.Cross(Vector3.up, dir))* transform.rotation;

     
    }


    // Use this for initialization
    new void Start()
    {
        base.Start();

        

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        //Debug.DrawRay(transform.position, Vector3.Cross(Vector3.up, dir), Color.red);

        if (isProcess)
        {
            if (Mathf.Abs(Quaternion.Dot(transform.rotation, quater)) != 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, quater, 0.3f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                isProcess = false;
            }
        }
    }
}
