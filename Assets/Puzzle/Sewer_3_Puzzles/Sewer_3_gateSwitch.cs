using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sewer_3_gateSwitch : MonoBehaviour {

    public sewer_3_movement down;
    public GameObject gatePad;
    public CameraManager cameraManager;

    bool moveUp = false;

    void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
    }

    void Update()
    {
        if (moveUp)
        {
            if (gatePad.transform.localPosition.y < -3.01)
            {
                gatePad.transform.position = new Vector3(gatePad.transform.position.x, gatePad.transform.position.y + Time.deltaTime * 5, gatePad.transform.position.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //down.gateDown = true;
            moveUp = true;
            FindObjectOfType<MusicManager>().Play("CircuitSound");
            cameraManager.CircuitTrigger[3].SetActive(true);
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    down.gateDown = false;
    //}

}
