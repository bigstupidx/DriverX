using UnityEngine;
using System.Collections;
using System;

public class EnergyLine : MonoBehaviour {

    Library library;

    private float lineWidth;
    private RectTransform energyLine;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();


        energyLine = transform.FindChild("Mask").FindChild("Energy").GetComponent<RectTransform>();
        lineWidth = energyLine.sizeDelta.x;

        CreateS();

    }

    private void CreateS()
    {

        GameObject[] s = new GameObject[4];
        for(int  i = 0; i < 4;i++)
        {
            s[0] = Instantiate(Resources.Load("Prefabs/UI/Risk")) as GameObject;
            s[0].transform.SetParent(transform.FindChild("Mask"));
            s[0].GetComponent<RectTransform>().localPosition = new Vector3((i+1)/4f*lineWidth - lineWidth/2, 0, 0);
       }
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
