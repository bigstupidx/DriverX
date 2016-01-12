using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Text.RegularExpressions;

public class MainBonus : MonoBehaviour {

    public const int MaxValue = 5;
    public static int count = MaxValue;
    DateTime lastDateTime;
    TimeSpan subtractTime;

    public const int RecoveryTime = 1800;

    // Use this for initialization
    void Start () {
        count = PreferencesSaver.GetMainBonus();
        lastDateTime = PreferencesSaver.GetMainBonusTime();
        subtractTime = new TimeSpan();
    }

    void Update()
    {
        DateTime nowTime = System.DateTime.Now;

        subtractTime = nowTime.Subtract(lastDateTime);

        if (subtractTime.TotalSeconds > RecoveryTime)
        {

            if (MainBonus.count < MainBonus.MaxValue)
            {
                AddItem();

                lastDateTime = nowTime;

                PreferencesSaver.SaveMainBonusTime(lastDateTime);
            }
        }

    }

    public bool IsAvailable()
    {
        if (count > 0)
            return true;
        else
            return false;
    }

    public void MinusItem()
    {
        if (count > 0)
        {
            if (count == MaxValue)
            {
                DateTime nowTime = System.DateTime.Now;
                lastDateTime = nowTime;
                PreferencesSaver.SaveMainBonusTime(nowTime);
            }

            count--;
            PreferencesSaver.SetMainBonus(count);
           
        }
    }

    public void AddItem()
    {
        if (count < MaxValue)
        {
            count++;
            PreferencesSaver.SetMainBonus(count);
        }
    }

    /*
    public static void AddItems(int col)
    {
        count += col;
    }*/

    public static DateTime GetNistTime() // Получение времени из интернета
    {
        DateTime dateTime = DateTime.MinValue;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
        request.Method = "GET";
        request.Accept = "text/html, application/xhtml+xml, */*";
        request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
        request.ContentType = "application/x-www-form-urlencoded";
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
            string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
            double milliseconds = Convert.ToInt64(time) / 1000.0;
            dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
        }

        return dateTime;
    }

    public int GetSubtractMinutes()
    {
        if (subtractTime == null)
            return 0;

        return subtractTime.Minutes;
    }

    public int GetSubtractSeconds()
    {
        if (subtractTime == null)
            return 0;
        return subtractTime.Seconds;
    }

}
