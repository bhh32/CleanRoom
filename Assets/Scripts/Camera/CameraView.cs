using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Renderer rend;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckView();
	}

    void CheckView()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        GameObject cachedObj = null;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                rend = hit.collider.GetComponent<Renderer>();
                rend.enabled = false;
                cachedObj = hit.collider.gameObject;
            }
        }

        if (cachedObj != null && hit.collider.tag != "Wall")
            rend.enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
            other.GetComponent<Renderer>().enabled = true;
    }
}
