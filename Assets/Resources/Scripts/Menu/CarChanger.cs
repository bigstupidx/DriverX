using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarChanger : MonoBehaviour {

    LibraryMenu libraryMenu;
    public GameObject car;
    public Button prew;
    public Button next;

    CarParametres carParametres;

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
        if (numCar+1 < libraryMenu.carsInfo.GetCarsCount())
        {
            foreach (Transform child in car.transform)
            {
                Destroy(child.gameObject);
            }

            if (carParametres != null)
                StartCoroutine(CreateCar(numCar + 1));
        }
    }

    void PrewCar()
    {
        int numCar = carParametres.GetNumCar();

        if (numCar > 0)
        {
            foreach (Transform child in car.transform)
            {
                Destroy(child.gameObject);
            }

            if (carParametres != null)
                StartCoroutine(CreateCar(numCar - 1));
        }
    }

    public void ShowCar()
    {
        foreach (Transform child in car.transform)
        {
            Destroy(child.gameObject);
        }
        int carNum = libraryMenu.preferencesSaver.GetCurrentCar();

        StartCoroutine(CreateCar(carNum));
    }



    IEnumerator CreateCar(int carNum)
    {
        CarParametres carParametres = libraryMenu.carsInfo.GetCarInfo(carNum);
        this.carParametres = carParametres;
        ResourceRequest rr = Resources.LoadAsync("Prefabs/UI/Cars/"+carParametres.GetName());
        yield return rr;
        
        GameObject carObject = Instantiate(rr.asset as GameObject);
        carObject.transform.parent = car.transform;

        carObject.transform.localPosition = new Vector3(0, 0, 0);
        carObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        carObject.transform.localScale = new Vector3(1, 1, 1);


    }
}
