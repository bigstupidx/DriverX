using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class Info : MonoBehaviour {

    static Dictionary<string, DestroyableInfo> destroyableInfoDictionary;
    static List<LevelInfo> levelInfoList;

    // Use this for initialization
    void Awake () {

        if (destroyableInfoDictionary == null)
            GetDestroyableInfoFromXML();
        

        if(levelInfoList == null)
            GetLevelInfoFromXML();
        

    }


    public void GetDestroyableInfoFromXML()
    {
        destroyableInfoDictionary = new Dictionary<string, DestroyableInfo>();


        TextAsset xmlAsset = Resources.Load("Info/DestroyableInfo") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);

        foreach (XmlNode node in xmlDoc.ChildNodes[0])
        {
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
            destroyableInfoDictionary.Add(node.Name, destroyableInfo);
        }

    }

    public void GetLevelInfoFromXML()
    {
        levelInfoList = new List<LevelInfo>();


        TextAsset xmlAsset = Resources.Load("Info/LevelInfo") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);

        foreach (XmlNode levelNode in xmlDoc.ChildNodes[0])
        {
            string name = levelNode.Attributes["name"].Value;
            int time = 0;

            foreach (XmlNode parametrNode in levelNode.ChildNodes[0])
            {
                switch (parametrNode.Attributes["name"].Value)
                {
                    case "time":
                        time = int.Parse(parametrNode.InnerText);
                        break;
                  
                }
            }


            LevelInfo levelInfo = new LevelInfo(name, time);
            levelInfoList.Add(levelInfo);
        }
    }

    public static DestroyableInfo GetDestroyableInfo(string name)
    {
        DestroyableInfo destroyableInfo;//= new DestroyableInfo(1,1,1);
        destroyableInfoDictionary.TryGetValue(name, out destroyableInfo);

        return destroyableInfo;
    }


    public static int GetLevelCount()
    {
       return levelInfoList.Count;
    }

    public static LevelInfo GetLevelInfo(int num)
    {
        if (num > levelInfoList.Count)
            return null;
        else
            return levelInfoList[num];
    }

}
