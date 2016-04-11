using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class BoosterButton : RawButton {

    public Text count;

    protected Library library;
    Button button;

    new void Start()
    {
        base.Start();
        library = GameObject.FindObjectOfType<Library>();
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { UseButton(); });
    }

    void UseButton()
    {
        DisableButton();
        UseButtonPersonal();
        UpdateCount();

    }

    abstract protected void UseButtonPersonal();

    public void ToDefault()
    {
        UpdateCount();

        if (count.text.Equals("0"))
            DisableButton();
    }

    abstract protected void UpdateCount();
}
