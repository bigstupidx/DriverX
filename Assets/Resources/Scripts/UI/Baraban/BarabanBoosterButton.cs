using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarabanBoosterButton : MonoBehaviour {

    public Text text;
    Library library;

	void Start () {
        GetComponent<Button>().onClick.AddListener(delegate { UseButton(); });
        library = GameObject.FindObjectOfType<Library>();
    }

    void Update () {
	
	}

    public void UseButton()
    {
        if(Bank.GetBarabanBooster() > 0)
        {
            Bank.MinusBarabanBooster(1);
        }

        text.text = Bank.GetBarabanBooster() + "";


        library.canvasController.GetBaraban().ShowBonus(1);

        UpdateStatusButton();

    }

    public void ToDefault()
    {
        text.text = Bank.GetBarabanBooster() + "";

        UpdateStatusButton();

    }

    public void UpdateStatusButton()
    {
        if (Bank.GetBarabanBooster() > 0)
        {
            GetComponent<RawButton>().EnableButton();
        }
        else
            GetComponent<RawButton>().DisableButton();

        if (library.canvasController.GetBaraban().sectors.GetComponent<BarabanSectorContainer>().AllIsActive())
            GetComponent<RawButton>().DisableButton();

       // Debug.Log(library.canvasController.GetBaraban().sectors.GetComponent<BarabanSectorContainer>().AllIsActive());
    }
}

