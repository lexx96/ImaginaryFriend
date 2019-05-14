using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    public CircuitManager circuitManager;
    public GameManager gameManager;

    public AudioSource keySound;

    void Start()
    {
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        keySound = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.name == "Key1")
                {
                    keySound.Play();
                    circuitManager.InteractUI.SetActive(false);
                    gameManager.Key1OBJ.SetActive(true);
                    GameManager.Key1 = true;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;
                }
                else if (gameObject.name == "Key2")
                {
                    keySound.Play();
                    circuitManager.InteractUI.SetActive(false);
                    gameManager.Key2OBJ.SetActive(true);
                    GameManager.Key2 = true;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;
                }
                else if (gameObject.name == "Key3")
                {
                    keySound.Play();
                    circuitManager.InteractUI.SetActive(false);
                    gameManager.Key3OBJ.SetActive(true);
                    GameManager.Key3 = true;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;
                }
                else if (gameObject.name == "Key4")
                {
                    keySound.Play();
                    circuitManager.InteractUI.SetActive(false);
                    gameManager.Key4OBJ.SetActive(true);
                    GameManager.Key4 = true;
                    GetComponent<Collider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;
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
}
