using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarChanger : MonoBehaviour {

    LibraryMenu libraryMenu;
    public GameObject car;
    public Button prew;
    public Button next;

    CarParametres carParametres;

    public static int NumCar; 

	// Use this for initialization
	void Start () {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();

        if (car == null)
            car = transform.FindChild("Car").gameObject;
        if (prew == null)
            prew = transform.FindChild("Prew").GetComponent<Button>();
        if (next == null)
            next = transform.FindChild("Next").GetComponent<Button>();

        next.onClick.AddListener(
            delegate
            {
                NextCar();
            }
        );

        prew.onClick.AddListener(
           delegate
           {
               PrewCar();
           }
       );

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void NextCar()
    {
        int numCar = carParametres.GetNumCar();
        NumCar = numCar;
        foreach (Transform child in car.transform)
        {
            Destroy(child.gameObject);
        }

        if (carParametres != null)
            StartCoroutine(CreateCar(numCar + 1));



        UpdateDisableButton();
    }

    void PrewCar()
    {
        int numCar = carParametres.GetNumCar();
        NumCar = numCar;
        foreach (Transform child in car.transform)
        {
            Destroy(child.gameObject);
        }

        if (carParametres != null)
            StartCoroutine(CreateCar(numCar - 1));
        UpdateDisableButton();
    }

    void UpdateDisableButton()
    {
        int numCar = carParametres.GetNumCar();

        NumCar = numCar;

        if (numCar + 1 >= libraryMenu.carsInfo.GetCarsCount())
            next.interactable = false;
        else
            next.interactable = true;

        if (numCar <= 0)
            prew.interactable = false;
        else
            prew.interactable = true;
    }

    public void ShowCar()
    {
        foreach (Transform child in car.transform)
        {
            Destroy(child.gameObject);
        }
        int carNum = PreferencesSaver.GetCurrentCar();

        StartCoroutine(CreateCar(carNum));

        UpdateDisableButton();
    }

    public void ToDefault()
    {
        ShowCar();
    
    }


    IEnumerator CreateCar(int carNum)
    {
        CarParametres carParametres = CarsInfo.GetCarInfo(carNum);
        this.carParametres = carParametres;
        


        libraryMenu.filling.UpdateAllPower(
            carParametres.GetParam(1),
            carParametres.GetParam(2), 
            carParametres.GetParam(3),
            PreferencesSaver.GetCarUpgrade(carNum, 1),
            PreferencesSaver.GetCarUpgrade(carNum, 2), 
            PreferencesSaver.GetCarUpgrade(carNum, 3));


        bool isOpen = PreferencesSaver.CarIsOpen(carNum);

        if (!isOpen)
        {
            libraryMenu.garage.ShowBuyButton(carParametres.GetCost());
            libraryMenu.garage.HidePlayButton();
            libraryMenu.garage.HideSecondPower();
        }
        else
        {
            libraryMenu.garage.HideBuyButton();
            libraryMenu.garage.ShowPlayButton();
            libraryMenu.garage.ShowSecondPower();
        }

        ResourceRequest rr = Resources.LoadAsync("Prefabs/UI/Cars/"+carParametres.GetName());
 

        yield return rr;
        
        GameObject carObject = Instantiate(rr.asset as GameObject);
        carObject.transform.SetParent(car.transform, false);

        carObject.transform.localPosition = new Vector3(0, 0, 0);
        carObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        carObject.transform.localScale = new Vector3(1, 1, 1);
        

    }

    public CarParametres GetCurrentCarParametres()
    {
        return carParametres;
    }

   
}
