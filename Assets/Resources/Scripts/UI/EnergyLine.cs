using UnityEngine;
using System.Collections;
using System;

public class EnergyLine : MonoBehaviour {

    Library library;

    private float lineWidth;
    private RectTransform energyLine;
    private RectTransform mask;
    // Use this for initialization
    void Start()
    {
        library = GameObject.FindObjectOfType<Library>();

        energyLine = transform.FindChild("Mask").FindChild("Energy").GetComponent<RectTransform>();
        lineWidth = energyLine.sizeDelta.x;

        mask = transform.FindChild("Mask").GetComponent<RectTransform>();

        CreateRaze();
    //    CreateS();

    }

    private void CreateRaze()
    {
        int razeCount = (int) Mathf.Floor(library.energy.GetMaxEnergy() / library.energy.GetNitroCost());

        for(int i = 1; i < razeCount; i++ )
        {
            GameObject razePrefab = Resources.Load("Prefabs/UI/Raze") as GameObject;
            GameObject raze = Instantiate(razePrefab);
            raze.transform.SetParent(transform);

            RectTransform razeRT = raze.GetComponent<RectTransform>();
            raze.GetComponent<RectTransform>().anchoredPosition = new Vector2(lineWidth / razeCount * i - lineWidth / 2f, (-1) * razeRT.sizeDelta.y);
        }
    }



    // Update is called once per frame
    void Update()
    {      

        updateHealth();
    }

    public void updateHealth()
    {
        float energy = library.energy.GetEnergy();
        float maxEnergy = library.energy.GetMaxEnergy();

        float maskSize = (((float)energy / (float)maxEnergy)) * lineWidth;

        maskSize = MathTools.ULerp(mask.sizeDelta.x, maskSize, 5f*Time.deltaTime);

        mask.sizeDelta = new Vector2(maskSize, mask.sizeDelta.y);

        float xPosLine = (maskSize  - lineWidth) / 2f;

        mask.anchoredPosition = new Vector2(xPosLine, mask.anchoredPosition.y);
    }

    public void ToDefault()
    {
        mask.sizeDelta = new Vector3(0.01f, mask.sizeDelta.y);
    }
}
