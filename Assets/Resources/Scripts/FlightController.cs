using UnityEngine;
using System.Collections;


public class FlightController : MonoBehaviour
{
    Library library;
    CarContact carContact;

    float fullTime;

    float firstTimer;
    float secondTimer;
    float threshold = 0.3f;

    bool isCoef;

    int mnozitel = 7;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();
        carContact = GetComponent<CarContact>();
    }

    // Update is called once per frame
    void Update()
    {
        if(carContact.IsFlight())
        {
            if(firstTimer < threshold)
                firstTimer += Time.deltaTime;
            else
            {
                if (!isCoef)
                {
                    library.score.AddCoef();
                    isCoef = true;
                    secondTimer += firstTimer;
                    fullTime += firstTimer;
                }

                fullTime += Time.deltaTime;

                secondTimer += Time.deltaTime;

                float preVal = secondTimer * mnozitel;

                int val = (int) Mathf.Floor(preVal);

                secondTimer = preVal - val;

                library.score.AddScore(val);
            }
        }
        else
        {
            secondTimer = 0;
            firstTimer = 0;
            isCoef = false;
        }
    }

    public float GetFullTime()
    {
        return fullTime;
    }

}
