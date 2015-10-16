using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class TaskStrings : MonoBehaviour
{

    Dictionary<string, TaskValue> obj = new Dictionary<string, TaskValue>();
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
                    List<string> fullText = new List<string>();
                    List<string> helperText = new List<string>();

                    foreach(XmlNode point in childVal.ChildNodes)
                    {
                        switch(point.Attributes["type"].Value)
                        {
                            case "fulltext": fullText.Add(point.InnerText); break;
                            case "helpertext": helperText.Add(point.InnerText); break;
                        }
                    }

                    
                    TaskValue taskValue = new TaskValue(fullText.ToArray(),helperText.ToArray());

                    try
                    {
                        obj.Add(childVal.Attributes["name"].Value, taskValue);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

        }



    }

    public TaskValue GetTaskValue(string name)
    {
        TaskValue taskValue;
        obj.TryGetValue(name, out taskValue);
        return taskValue;
    }
}