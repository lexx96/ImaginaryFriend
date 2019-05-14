using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewer_1_Manager : MonoBehaviour {

    public int counter;
    public CameraManager cameraManager;

	void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
    }

    void Update()
    {
        if (counter == 3)
        {
            cameraManager.CircuitTrigger[2].SetActive(true);
            FindObjectOfType<MusicManager>().Play("CircuitSound");
            Destroy(gameObject);
        }
    }
}
