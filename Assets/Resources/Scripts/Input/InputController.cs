using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class InputController : MonoBehaviour {

    GameObject leftButton;
    GameObject rightButton;

    GameObject car;

    void Start () {
        leftButton = transform.FindChild("LeftButton").gameObject;
        rightButton = transform.FindChild("RightButton").gameObject;

        car = GameObject.Find("Car");

        setDefaultButtons();

    }

    void FixedUpdate()
    {
        bool leftIsUse = leftButton.GetComponent<GameControllButton>().IsUse();
        bool rightIsUse = rightButton.GetComponent<GameControllButton>().IsUse();

        if ((leftIsUse && !rightIsUse) || (!leftIsUse && rightIsUse))
        {
            if (leftIsUse)
                car.GetComponent<Move>().MinusWheelRotation();

            if (rightIsUse)
                car.GetComponent<Move>().PlusWheelRotation();
        }
        else
            car.GetComponent<Move>().ToZeroWheelRotation();

    }

    private void setDefaultButtons()
    {
        RectTransform rectLeft = leftButton.GetComponent<RectTransform>();
        rectLeft.sizeDelta = new Vector2(Screen.width / 2, Screen.height);
        rectLeft.localPosition = new Vector3(-rectLeft.sizeDelta.x / 2, 0, 0);


        RectTransform rectRight = rightButton.GetComponent<RectTransform>();
        rectRight.sizeDelta = new Vector2(Screen.width / 2, Screen.height);
        rectRight.localPosition = new Vector3(rectRight.sizeDelta.x / 2, 0, 0);

        leftButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        rightButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
   

}
