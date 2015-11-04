using UnityEngine;
using System.Collections;
using System;

public class TaskMenuStartButton : MenuButton
{
    protected override void OnClick()
    {
        libraryMenu.kaController.ShowLevel();
    }

  
}
