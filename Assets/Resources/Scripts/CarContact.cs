using UnityEngine;
using System.Collections.Generic;
using System;

public class CarContact : MonoBehaviour {

    Library library;
    Vector3 dir = new Vector3();
    Vector3 lastPos = new Vector3();

    Dictionary<string,int> dictionaryDestroyable = new Dictionary<string, int>();

    void Start () {
        // transform.GetComponent<Collider>().isTrigger = true;
        library = GameObject.Find("Global").GetComponent<Library>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        UpdateDirection();        
	}

    private void UpdateDirection()
    {
        dir = (transform.position - lastPos).normalized;
        lastPos = transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
 
        Destroyable destoyable = col.gameObject.GetComponent<Destroyable>();

        if (destoyable != null)
        {
            destoyable.OnCollision(transform);
            library.score.AddScoreForDestroy(destoyable);
            library.energy.AddEnergy(destoyable);

            CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(3, 3, 0.1f, 2f);

            AddDestroyable(destoyable.GetType().Name);
        }


        //   c.PositionInfluence = new Vector3(1,1,1);
        // c.PositionInfluence = new Vector3(1, 1, 1);
    }

    private void AddDestroyable(String name)
    {
        int val = 0;

        if (dictionaryDestroyable.TryGetValue(name, out val))
            dictionaryDestroyable[name] += 1;
        else
            dictionaryDestroyable.Add(name, 1);

    }

    public Vector3 GetDirection()
    {
        return dir;
    }

    public int GetDestroyableCount(string name)
    {
        int val = 0;

        if (dictionaryDestroyable.TryGetValue(name, out val))
            return val;
        else
            return 0;
    }

}
