using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
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
                if (gameObject.name == "Trig_L_1")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Trig_L_1");
                    circuitManager.LightTriggers[3].GetComponent<Light>().enabled = true;
                }
                else if (gameObject.name == "Trig_L_2")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Trig_L_2");
                    circuitManager.LightTriggers[1].GetComponent<Light>().enabled = true;
                }
                else if (gameObject.name == "Trig_L_3")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Trig_L_3");
                    circuitManager.LightTriggers[0].GetComponent<Light>().enabled = true;
                }
                else if (gameObject.name == "Trig_L_4")
                {
                    Destroy(gameObject);
                    DestroyTrigger("Trig_L_4");
                    circuitManager.LightTriggers[2].GetComponent<Light>().enabled = true;
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
