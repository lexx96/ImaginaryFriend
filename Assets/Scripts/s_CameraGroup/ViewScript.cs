using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScript : MonoBehaviour {
    [Header("Auto Fill")]
    public CameraView cameraView;

	void Start ()
    {
        cameraView = GameObject.Find("ViewTriggers").GetComponent<CameraView>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "3rdPersonView" && other.CompareTag("Player"))
        {
            cameraView.smoothTo3rdPerson = true;
        }

        if (gameObject.name == "SideScrollerView" && other.CompareTag("Player"))
        {
            cameraView.smoothToSideView = true;
        }

        if (gameObject.name == "TopDownView" && other.CompareTag("Player"))
        {
            cameraView.smoothToTopDown = true;
        }
    }
}
