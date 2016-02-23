using UnityEngine;
using System.Collections;

public class BarabanSectorContainer : MonoBehaviour {

    float[] startPositions;
    public RectTransform[] sectors;


    Library library;
    RectTransform rt;
	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        library = GameObject.FindObjectOfType<Library>();

        startPositions = new float[sectors.Length];

        for(int i = 0; i < sectors.Length; i++)
        {
            startPositions[i] = sectors[i].anchoredPosition.x;
        }
	}
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < sectors.Length; i++)
        {
            Vector3 sectorgp = (-1)*sectors[i].InverseTransformPoint(library.canvasController.GetComponent<RectTransform>().anchoredPosition);

            if (sectorgp.x > rt.rect.width/2f + rt.rect.width/10f/2f)
            {
                Vector2 ap = sectors[i].anchoredPosition;
                ap.x -= rt.rect.width;
                sectors[i].anchoredPosition = ap; 
            }
        }
	}

    public GameObject[] SetActiveElements(int count)
    {
        int curCount = count;

        GameObject[] objects = new GameObject[count];
        int i = 0;
        while (curCount > 0)
        {
            int random = Random.Range(0, 10);

            if (!sectors[random].gameObject.activeSelf)
            {
                sectors[random].gameObject.SetActive(true);
                objects[i] = sectors[random].gameObject;
                i++;
                curCount--;

            }
        }

        return objects;

    }



    public void UnSelectAll()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public bool IsActive(int num)
    {
        if (sectors[num].gameObject.activeSelf)
            return true;
        else
            return false;
    }

    public void ToDefault()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, GetComponent<RectTransform>().anchoredPosition.y);

        for (int i = 0; i < sectors.Length;i++)
        {
            sectors[i].anchoredPosition = new Vector2(startPositions[i], sectors[i].anchoredPosition.y);
        }
        UnSelectAll();

    }

    public bool AllIsActive()
    {
        bool val = true;

        for (int i = 0; i < sectors.Length; i++)
        {
            val = val & sectors[i].gameObject.activeSelf;
        }

        return val;
    }
}
