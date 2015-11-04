using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GarageTaskButton : MenuButton
{
    protected override void OnClick()
    {
        libraryMenu.kaController.ShowTasksMenu();
    }
}
