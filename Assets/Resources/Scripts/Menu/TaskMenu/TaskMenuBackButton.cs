using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TaskMenuBackButton : MenuButton
{
    protected override void OnClick()
    {
        libraryMenu.kaController.ShowGarage();
    }
}
