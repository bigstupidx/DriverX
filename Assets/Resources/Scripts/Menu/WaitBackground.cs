using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaitBackground : MonoBehaviour {

    Image image;
    // Use this for initialization
    void Start() {
        image = GetComponent<Image>();
    }

    public void Show()
    {
      //  iTween.FadeTo(gameObject, 1, 2);
         image.enabled = true;
        iTween.ValueTo(gameObject,
            iTween.Hash("from", image.color.a,
             "to", 1,
             "time", 0.2f,
             "onupdate", "OnUpdate"
             )
        );
    }

    public void ToDefault()
    {
        image.enabled = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    public void Hide()
    {
        iTween.FadeTo(gameObject, 0, 2);
        iTween.ValueTo(gameObject,
            iTween.Hash("from", image.color.a,
             "to", 0,
              "time", 0.2f,
             "onupdate", "OnUpdate",
             "oncomplete", "OnCompleteHide",
             "oncompletetarget", gameObject
             )

            
        );
        // image.enabled = false;
    }

    void OnCompleteHide()
    {
        image.enabled = false;
    }

    void OnUpdate(float newVal)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, (float)newVal);
    }
}

