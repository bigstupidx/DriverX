using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GarageTaskButton : MenuButton
{
    protected override void OnClick()
    {
        PreferencesSaver.SaveCurrentCar(libraryMenu.carChanger.GetCurrentCarParametres().GetNumCar());
        libraryMenu.kaController.ShowTasksMenu();
    }
}
