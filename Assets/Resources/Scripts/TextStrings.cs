using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class TextStrings : MonoBehaviour {

    static Dictionary<string, string> textStrings;

    // Use this for initialization
    void Awake()
    {
        if (textStrings == null)
            GetTextStringsFromXML();
    }


    public void GetTextStringsFromXML()
    {
        textStrings = new Dictionary<string, string>();


        TextAsset xmlAsset = Resources.Load("Info/Strings") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);


        XmlNode lang;

        lang = xmlDoc.ChildNodes[0].ChildNodes[0]; // тут выбираем язык

        foreach (XmlNode node in lang)
        {
            
            textStrings.Add(node.Attributes["name"].Value, node.InnerText);
        }

    }



    public static string GetString(string name)
    {
        string str;
        textStrings.TryGetValue(name, out str);

        return str;
    }


    

}
