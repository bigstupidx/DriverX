using UnityEngine;
using System.Collections;

public class Poddon : MonoBehaviour {


    bool isCollide;

    float time;

    float porog = 1f;
	// Use this for initialization
	
	void OnTriggerEnter(Collider collider)
    {
        if (!collider.tag.Equals("Ground"))
        isCollide = true;
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (!collider.tag.Equals("Ground"))

            isCollide = true;

    }

    void OnTriggerExit(Collider collider)
    {
        isCollide = false;
        time = 0;


    }

    void Update()
    {
        if(isCollide)
        {
            time += Time.deltaTime;
        }
    }

    public bool IsZavis()
    {
        if (isCollide && time > porog)
        {
            return true;
        }
        else
            return false;
    }
}
