using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class TaskStrings : MonoBehaviour
{

    Dictionary<string, string> obj = new Dictionary<string, string>();
    // Use this for initialization
    void Awake()
    {
        TextAsset xmlAsset = Resources.Load("Info/TaskStrings") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);



        foreach (XmlNode node in xmlDoc.ChildNodes[0])
        {
            if (node.Name.Equals("ru"))
            {
                foreach (XmlNode childVal in node.ChildNodes)
                {
                    try
                    {
                        obj.Add(childVal.Attributes["name"].Value, childVal.InnerText);
                    }
                    catch (System.Xml.XmlException)
                    {
                        continue;
                    }
                }
            }

        }



    }

    public string GetString(string name)
    {
        string str;
        obj.TryGetValue(name, out str);
        return str;
    }
}