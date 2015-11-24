using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class CarsInfo : MonoBehaviour {

    List<CarParametres> obj = new List<CarParametres>();
    // Use this for initialization
    void Awake()
    {
        TextAsset xmlAsset = Resources.Load("Info/Cars") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);

        foreach (XmlNode node in xmlDoc.ChildNodes[0])
        {
            CarParametres carParametres = new CarParametres(obj.Count,node.Attributes["name"].Value); 
            obj.Add(carParametres);
        }
    }

    public CarParametres GetCarInfo(int num)
    {
        return obj[num];
    }
    
    public int GetCarsCount()
    {
        return obj.Count;
    }
    /*
    public CarParametres GetCarParametres(string name)
    {
        CarParametres carParametres;
        obj.TryGetValue(name, out carParametres);

        return carParametres;
    }*/
}
