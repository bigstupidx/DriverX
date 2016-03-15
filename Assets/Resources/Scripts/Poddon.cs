using UnityEngine;
using System.Collections;

public class Poddon : MonoBehaviour {


    bool isCollide;

    float time;

    float porog = 2f;

    Collider curCollider;

    
	// Use this for initialization
	
        
	void OnTriggerEnter(Collider collider)
    {
        //if (!collider.tag.Equals("Car"))
            isCollide = true;

    }

    
    void OnTriggerStay(Collider collider)
    {
        //   if (!collider.tag.Equals("Car"))
        /*

        if (!collider.Equals(curCollider) && time > 1)
            time = 0;

            time += Time.fixedTime;

        curCollider = collider;
        isCollide = true;*/
        //  Debug.Log("Stay " + collider.gameObject);
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
