using UnityEngine;
using System.Collections;
using System;

public class StartMenuButton : MenuButton
{
    protected override void OnClick()
    {
        libraryMenu.kaController.ShowLevel();
    }

  
}
