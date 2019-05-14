using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Socket : MonoBehaviour {

    public CircuitManager circuitManager;
    public GameManager gameManager;

    void Start ()
    {
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            circuitManager.InteractUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.Key1 && gameObject.name == "Key1_Socket")
                {
                    ++gameManager.keyInserted;
                    FindObjectOfType<MusicManager>().Play("CircuitSound");
                    gameManager.Key1OBJ.SetActive(false);
                    circuitManager.InteractUI.SetActive(false);
                    GameManager.Key1 = false;
                    Destroy(GetComponent<Key_Socket>());
                }
                else if (GameManager.Key2 && gameObject.name == "Key2_Socket")
                {
                    ++gameManager.keyInserted;
                    FindObjectOfType<MusicManager>().Play("CircuitSound");
                    gameManager.Key2OBJ.SetActive(false);
                    circuitManager.InteractUI.SetActive(false);
                    GameManager.Key2 = false;
                    Destroy(GetComponent<Key_Socket>());
                }
                else if (GameManager.Key3 && gameObject.name == "Key3_Socket")
                {
                    ++gameManager.keyInserted;
                    FindObjectOfType<MusicManager>().Play("CircuitSound");
                    gameManager.Key3OBJ.SetActive(false);
                    circuitManager.InteractUI.SetActive(false);
                    GameManager.Key3 = false;
                    Destroy(GetComponent<Key_Socket>());
                }
                else if (GameManager.Key4 && gameObject.name == "Key4_Socket")
                {
                    ++gameManager.keyInserted;
                    FindObjectOfType<MusicManager>().Play("CircuitSound");
                    gameManager.Key4OBJ.SetActive(false);
                    circuitManager.InteractUI.SetActive(false);
                    GameManager.Key4 = false;
                    Destroy(GetComponent<Key_Socket>());
                }
            }
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
