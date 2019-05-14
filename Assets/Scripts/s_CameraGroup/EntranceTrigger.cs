using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour {

    [Header("Auto Fill")]
    public CameraManager cinematicCamera;
    public GameObject _Blockade1;
    public GameObject AI_Beckoning;

    void Start ()
    {
        cinematicCamera = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        _Blockade1 = GameObject.Find("Blockade1");
        AI_Beckoning.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Equals("e_Trigger1") && other.CompareTag("Player"))
        {
            if (cinematicCamera.CameraObj.transform.position != cinematicCamera.e_CameraPosition[1].transform.position)
            {
                cinematicCamera.e_Cam1 = false;
                cinematicCamera.e_Cam2 = true;
                _Blockade1.GetComponent<Collider>().enabled = true;
                AI_Beckoning.SetActive(true);
            }
        }
    }
}
