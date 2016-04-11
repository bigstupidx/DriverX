using System.Collections;

public class Gift {

    public enum GiftType
    {
        Money,Booster1,Booster2,Booster3,Bonus,Box
    }

    public GiftType type;
    public int val1;
    public int val2;
    public int val3;
    public int val4;
    public int val5;

    public bool isMain;
}
