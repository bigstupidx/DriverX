using UnityEngine;
using System.Collections;

public class MathTools {

	public static int GetZnak(float val)
    {
        if (val < 0)
            return -1;
        else
            return 1;
    }
}
