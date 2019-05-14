using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public MovingBox movingBox;
    public GameObject EkeyUI;
    bool isActive = true;

    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isActive = false;
                movingBox.moveFor = true;
                EkeyUI.SetActive(false);
            }
        }

        if (isActive)
        {
            EkeyUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            EkeyUI.SetActive(false);
        }
    }

}
