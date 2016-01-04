using UnityEngine;
using System.Collections;

public class FinalPoint : MonoBehaviour {

    private Particle round;
    Library library;
    // Use this for initialization
    void Start () {
        round = GetComponent<Particle>();
        library = GameObject.FindObjectOfType<Library>();
    }

    void OnTriggerEnter(Collider other)
    {
        FindLevelExit fle = library.level.GetComponentInChildren<FindLevelExit>();

        if (fle != null)
            fle.SetTake();

        Destroy(round.gameObject);
        library.timerScript.SetEnd();


    }
}
