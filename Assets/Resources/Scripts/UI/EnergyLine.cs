using UnityEngine;
using System.Collections;
using System;

public class EnergyLine : MonoBehaviour {

    Library library;

    private float lineWidth;
    private RectTransform energyLine;
    private RectTransform mask;
    // Use this for initialization

    void Awake()
    {
        library = GameObject.FindObjectOfType<Library>();

    }

    void Start()
    {

        energyLine = transform.FindChild("Mask").FindChild("Energy").GetComponent<RectTransform>();
        lineWidth = energyLine.sizeDelta.x;

        mask = transform.FindChild("Mask").GetComponent<RectTransform>();

     //   CreateRaze();
    //    CreateS();

    }

    public void CreateRaze()
    {
        float sectorCount = library.energy.GetMaxEnergy() / library.energy.GetNitroCost();
        int razeCount = 0;


        if (Mathf.Floor(sectorCount) == Mathf.Ceil(sectorCount))
        {
            razeCount = (int)sectorCount - 1;
        }
        else
            razeCount = (int)Mathf.Floor(sectorCount);


        for(int i = 1; i <= razeCount; i++ )
        {
            GameObject razePrefab = Resources.Load("Prefabs/UI/Raze") as GameObject;
            GameObject raze = Instantiate(razePrefab);
            raze.transform.SetParent(transform);

            RectTransform razeRT = raze.GetComponent<RectTransform>();
            raze.GetComponent<RectTransform>().anchoredPosition = new Vector2(1f/sectorCount * i * lineWidth - lineWidth/2f, (-1) * razeRT.sizeDelta.y/2f);
            raze.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }



    // Update is called once per frame
    void Update()
    {      
        updateHealth();
    }

    void updateHealth()
    {
        float energy = library.energy.GetEnergy();
        float maxEnergy = library.energy.GetMaxEnergy();

        float maskSize = (((float)energy / (float)maxEnergy)) * lineWidth;

        maskSize = MathTools.ULerp(mask.sizeDelta.x, maskSize, 3f*Time.deltaTime);

        mask.sizeDelta = new Vector2(maskSize, mask.sizeDelta.y);

        float xPosLine = (maskSize  - lineWidth) / 2f;
        
        Vector2 temp = new Vector2(xPosLine, mask.anchoredPosition.y);

        if(!mask.anchoredPosition.Equals(temp))
            mask.anchoredPosition = temp;
    }

    public void ToDefault()
    {
        mask.sizeDelta = new Vector3(0.01f, mask.sizeDelta.y);
    }

    public void SetMaxEnergy()
    {
        float maskSize = lineWidth;

        mask.sizeDelta = new Vector2(maskSize, mask.sizeDelta.y);

        float xPosLine = 0;

        mask.anchoredPosition = new Vector2(xPosLine, mask.anchoredPosition.y);
    }
}
