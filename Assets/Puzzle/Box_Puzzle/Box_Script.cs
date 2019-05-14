using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Script : MonoBehaviour {

    public GameObject dropBoxObj;
    public CameraManager cameraManager;
    public static bool dropBox = false;

	void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
    }
	
	void Update ()
    {
        if (dropBox)
        {
            dropBox = false;
            dropBoxObj.GetComponent<Rigidbody>().useGravity = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("DroppingBox"))
        {
            cameraManager.CircuitTrigger[12].SetActive(true);
        }
    }
}
