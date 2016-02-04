using UnityEngine;
using System.Collections;

public class CraneDrop : MonoBehaviour
{

    public GameObject plane;

    private Particle round;

    Library library;
    // Use this for initialization
    void Start()
    {
        round = GetComponent<Particle>();
        library = GameObject.FindObjectOfType<Library>();
    }



    void OnTriggerEnter(Collider other)
    {
        plane.GetComponent<Rigidbody>().isKinematic = false;
        plane.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -1), ForceMode.Impulse);
        library.secondCamera.SetActive(true);
        Destroy(round.GetParticle().gameObject);
        Destroy(GetComponent<Collider>());

        StartCoroutine(HideCamera());
    }

    IEnumerator HideCamera()
    {
        yield return new WaitForSeconds(2.5f);
        library.secondCamera.SetActive(false);
        Destroy(round.gameObject);

    }

}