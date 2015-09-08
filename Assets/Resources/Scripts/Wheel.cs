using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Wheel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    bool isUse = false;
    GameObject image;


    private float baseAngle = 0.0f;

    private float angle;
    private float thresholdAngle = 150;


    void Start()
    {
        image = transform.FindChild("WheelImage").gameObject;

    }


    public void OnDrag(PointerEventData eventData)
    {


        Vector3 localPosition = new Vector3(eventData.position.x, eventData.position.y, 0) - GetComponent<RectTransform>().position;
        float tempAngle = Angle(
                localPosition.normalized,
                new Vector3(0, 1, 0));

        if (float.IsNaN(tempAngle))
            return;

        if (tempAngle > thresholdAngle)
            return;

        if (localPosition.x > 0)
            tempAngle *= -1;

        if (Mathf.Abs(angle - tempAngle) > 180)
            return;

        angle = tempAngle;



        
      
    }

    public static float Angle(Vector3 start, Vector3 end)
    {
        start.Normalize();
        end.Normalize();


        return Mathf.Acos((start.x * end.x + start.y * end.y) / (start.magnitude * end.magnitude)) * 180 / Mathf.PI;
   
    }

    // Use this for initialization
 

    // Update is called once per frame
    void Update () {
        GetComponent<RectTransform>().rotation = Quaternion.Slerp(GetComponent<RectTransform>().rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 10);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        angle = 0;
    }

    public float GetAngle()
    {
        return angle;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }
}
