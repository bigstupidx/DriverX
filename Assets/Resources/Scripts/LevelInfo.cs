using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour {

    Dictionary<string,DestroyableInfo> obj = new Dictionary<string, DestroyableInfo>();
	// Use this for initialization
	void Awake () {
        TextAsset xmlAsset = Resources.Load("Info/Values") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);

        foreach (XmlNode node in xmlDoc.ChildNodes[0])
        {
            int minEnergy = 0;
            int rewardEnergy = 0;
            int cost = 0;

            foreach (XmlNode childVal in node.ChildNodes)
            {
                switch (childVal.Name)
                {
                   
                    case "rewardEnergy":
                        rewardEnergy = int.Parse(childVal.InnerText);
                        break;
                    case "cost":
                        cost = int.Parse(childVal.InnerText);
                        break;
                }
            }
            DestroyableInfo destroyableInfo = new DestroyableInfo(cost, rewardEnergy);
            obj.Add(node.Name, destroyableInfo);
        }

        

    }

    public DestroyableInfo GetDestroyableInfo(string name)
    {
        DestroyableInfo destroyableInfo;//= new DestroyableInfo(1,1,1);
        obj.TryGetValue(name, out destroyableInfo);

        return destroyableInfo;
    }
}
