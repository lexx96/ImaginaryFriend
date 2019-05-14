using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewer1_Puzzle : MonoBehaviour {

    public CircuitManager circuitManager;
    public sewer_1_Manager manager;

    void Start()
    {
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
    }

    void OnTriggerStay(Collider other)
    {
        circuitManager.InteractUI.SetActive(true);
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            manager.counter++;
            circuitManager.InteractUI.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(false);
        }
    }
}
