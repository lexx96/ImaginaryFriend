using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTriggers : MonoBehaviour {

    public CircuitManager circuitManager;

    private void Start()
    {
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
        circuitManager.InteractUI.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.name == "Emp1")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Emp1");
                }
                else if (gameObject.name == "Emp2")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Emp2");
                }
                else if (gameObject.name == "Emp3")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Emp3");
                }
            }
            
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(false);
        }
    }
    void DestroyTrigger(string triggerName)
    {
        if (gameObject.name == triggerName)
        {
            if (gameObject.activeInHierarchy)
            {
                circuitManager.InteractUI.SetActive(false);
            }
            else
            {
                circuitManager.InteractUI.SetActive(true);
            }
        }
    }
}
