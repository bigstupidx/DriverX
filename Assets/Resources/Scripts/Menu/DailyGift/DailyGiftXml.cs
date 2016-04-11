using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class DailyGiftXml : MonoBehaviour
{

    static List<Gift> obj = new List<Gift>();
    LibraryMenu libraryMenu;
    // Use this for initialization
    void Awake()
    {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        TextAsset xmlAsset = Resources.Load("Info/DailyGift") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset)
            xmlDoc.LoadXml(xmlAsset.text);

        foreach (XmlNode node in xmlDoc.ChildNodes[0])
        {
            Gift gift = new Gift();

           if(node.Attributes["type"].Value.Equals("box"))
           {
                gift.type = Gift.GiftType.Box;
                gift.val1 = int.Parse(node.Attributes["val1"].Value);
                gift.val2 = int.Parse(node.Attributes["val2"].Value);
                gift.val3 = int.Parse(node.Attributes["val3"].Value);
                gift.val4 = int.Parse(node.Attributes["val4"].Value);
                gift.val5 = int.Parse(node.Attributes["val5"].Value);
            }
           else
            {
                switch(node.Attributes["type"].Value)
                {
                    case "money": gift.type = Gift.GiftType.Money; break;
                    case "booster1": gift.type = Gift.GiftType.Booster1; break;
                    case "booster2": gift.type = Gift.GiftType.Booster2; break;
                    case "booster3": gift.type = Gift.GiftType.Booster3; break;
                    case "bonus": gift.type = Gift.GiftType.Bonus; break;
                }
                gift.val1 = int.Parse(node.Attributes["val"].Value);

            }
            gift.isMain = bool.Parse(node.Attributes["isMain"].Value);
            obj.Add(gift);
        }
    }

    public static Gift GetGift(int num)
    {

        if (num >= obj.Count)
            return null;
        else
            return obj[num];
    }

    public static int GetGiftCount()
    {
        return obj.Count;
    }
  
}