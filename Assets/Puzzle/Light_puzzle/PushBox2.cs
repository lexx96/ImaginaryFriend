using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox2 : MonoBehaviour {

    public MovingBox2 movingBox2;
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
                Destroy(gameObject);
                DestroyTrigger("Pushbox2");
                movingBox2.moveFor2 = true;   
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
