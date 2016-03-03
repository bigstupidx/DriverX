using UnityEngine;
using System.Collections;

public class BarabanSector : MonoBehaviour {

    public GameObject[] images = new GameObject[2];

    public GameObject numImg;

    bool isActive = false;
	public void Activate()
    {
        images[0].SetActive(true);
        images[1].SetActive(true);
        isActive = true;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void Deactive()
    {
        images[0].SetActive(false);
        images[1].SetActive(false);
        isActive = false;
    }
}
