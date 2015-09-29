using UnityEngine;
using System.Collections;

public class EnergyLine : MonoBehaviour {

    Library library;

    public Transform target;

    private float lineWidth;
    private RectTransform energyLine;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();


        energyLine = transform.FindChild("Mask").FindChild("Energy").GetComponent<RectTransform>();
        lineWidth = energyLine.sizeDelta.x;


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }*/

      

        updateHealth();
    }

    public void updateHealth()
    {
        float energy = library.energy.GetEnergy();
        float maxEnergy = library.energy.GetMaxEnergy();

        float xPosLine = (((float)energy / (float)maxEnergy) - 1) * lineWidth;

        energyLine.anchoredPosition = new Vector2(xPosLine, energyLine.anchoredPosition.y);
    }
}
