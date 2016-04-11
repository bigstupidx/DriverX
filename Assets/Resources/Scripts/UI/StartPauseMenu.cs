using UnityEngine;
using System.Collections;

public class StartPauseMenu : MonoBehaviour {

    public BoosterButton[] boosterButtons = new BoosterButton[2];

    public void ToDefault()
    {
        for (int i = 0; i < boosterButtons.Length; i++)
            boosterButtons[i].ToDefault();
    }
}
