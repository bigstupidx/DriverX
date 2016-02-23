using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    float timeLeft;
    Library library;
    bool isShow;

    bool isPlay = false;
    void Start () {
        library = FindObjectOfType<Library>();
        ToDefault();
	}

    public void ToDefault()
    {
        timeLeft = 5;//Info.GetLevelInfo(StaticValues.NumLevel).GetTime();
        isShow = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (isPlay)
        {
            timeLeft = Mathf.Clamp(timeLeft - Time.deltaTime, 0, 1000);

            if (timeLeft == 0 && !isShow)
            {
                SetEnd();
            }
        }
    }

    public void SetEnd()
    {
        isShow = true;
        isPlay = false;
        timeLeft = 0;
        library.globalController.TimerIsEnd();
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetStart()
    {
        isPlay = true;
    }

}
