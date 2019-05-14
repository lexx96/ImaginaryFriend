using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollLaugh : MonoBehaviour {

    public CircuitManager circuitManager;

    public AudioSource Laugh;

    public void Start()
    {
        Laugh = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(true);
            Laugh.Play();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(false);
        }
    }
}
