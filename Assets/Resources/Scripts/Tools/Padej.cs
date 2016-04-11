using UnityEngine;
using System.Collections;

public class Padej {

    public static int GetPadej(int fullCount)
    {
        int strNum = 1;

        if (fullCount == 0 || (fullCount >= 10 && fullCount <= 20) || fullCount % 10 >= 5)
            strNum = 3;
        else if (fullCount % 10 == 1)
            strNum = 1;
        else if (fullCount % 10 >= 2 && fullCount % 10 <= 4)
            strNum = 2;

        return strNum;
    }
}
