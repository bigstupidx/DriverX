using UnityEngine;
using UnityEngine.UI;
using com.playGenesis.VkUnityPlugin;
using Facebook.MiniJSON;
using System.Collections.Generic;

public class EnterVk : MonoBehaviour {

    LibraryMenu libraryMenu;

    public Button button;
    public VkApi vkapi;

    int numBonusCar = 1;

    string group_id = "115627109";
    // Use this for initialization
    void Start () {

        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        vkapi = VkApi.VkApiInstance;
        button.onClick.AddListener(
            delegate
            {
                InitializeGroupRequest();
              
            }
        );
    }



    public void EnterInGroupVk()
    {
        if (vkapi.TokenValidFor() < 120)
            Login();

        JoinGroupRequest();
    }

    public void Login()
    {
        vkapi.Login();
    }

    public void InitializeGroupRequest()
    {
       //Debug.Log("IsUserLogin "+!vkapi.isUserLoggedIn);
       // if (!vkapi.isUserLoggedIn)
     //   {
            vkapi.LoggedIn += EnterInGroupVk;
            Login();
      //  }
    //    else
   //     {
    //        EnterInGroupVk();
    //    }
    }



    public void JoinGroupRequest()
    {

        string request = "groups.join?group_id="+group_id+"&access_token=" + VkApi.currentToken.access_token; ;

        vkapi.Call(request, JoinGroupHandler);
    }

    public void JoinGroupHandler(VkResponseRaw _raw, object[] _arguments)
    {
        if (_raw.ei != null && _raw.ei.error_code.Equals("17"))
        {
            libraryMenu.windowWarning.Show("ВКонтакте требует прохождения процедуры валидации пользователя.");
            return;
        }


        var dict = Json.Deserialize(_raw.text) as Dictionary<string, object>;
        long resp = (long) dict["response"];

      
        if (resp == 1)
        {
            PreferencesSaver.UserJoinInGroupVK();
            PreferencesSaver.OpenCar(numBonusCar);
            libraryMenu.carChanger.ShowCar();
        }
        else
        {
            libraryMenu.windowWarning.Show("Превышено ограничение на количество вступлений.");
        }

    }
}
