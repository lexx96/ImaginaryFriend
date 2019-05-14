using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitTrigger : MonoBehaviour {

    public float maxTime = 5f;
    public float curTime = 0f;

    public bool isCounting = false;

    #region Auto Fill & Private Variables
    [Header("Auto Fill")]
    public CameraManager cameraManager;
    public CircuitManager circuitManager;
    public LockScript lockScript;
    public GameObject lockObj;
    public room4_spikePad spikePad;
    #endregion

    void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
        spikePad = GameObject.Find("spike").GetComponent<room4_spikePad>();
        curTime = maxTime;

        circuitManager.InteractUI.SetActive(false);
    }
	
	void Update ()
    {
        if (isCounting)
        {
            curTime -= Time.deltaTime;

            if (curTime < 0f)
            {
                isCounting = false;
                curTime = maxTime;
            }
        }

        if (lockObj == isActiveAndEnabled)
        {
            if (gameObject.name == "c_Lock1")
            {
                if (lockScript.lockCode[0] == 1 && lockScript.lockCode[1] == 9 && lockScript.lockCode[2] == 9 && lockScript.lockCode[3] == 5)
                {
                    FindObjectOfType<MusicManager>().Play("CircuitSound");
                    cameraManager.CircuitTrigger[0].SetActive(true);
                    lockObj.SetActive(false);
                    Destroy(circuitManager.Triggers[0]);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        CheckInteractableUI();

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.name == "c_Lock1")
            {
                lockObj.SetActive(true);
            }
            else if (gameObject.name == "c_Trigger2")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger2");
                circuitManager.PushBox.GetComponent<BoxCollider>().enabled = true;
                circuitManager.Manhole.transform.position = new Vector3(circuitManager.Manhole.transform.position.x, circuitManager.Manhole.transform.position.y, 150f);
                cameraManager.CircuitTrigger[1].SetActive(true);
            }
            else if (gameObject.name == "l_Trigger3")
            {
                Destroy(gameObject);
                DestroyTrigger("l_Trigger3");
                cameraManager.CircuitTrigger[2].SetActive(true);
            }
            else if (gameObject.name == "l_Trigger4")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("l_Trigger4");
                cameraManager.CircuitTrigger[3].SetActive(true);
            }
            else if (gameObject.name == "l_Trigger5")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("l_Trigger5");
                cameraManager.CircuitTrigger[4].SetActive(true);
            }
            else if (gameObject.name == "l_Trigger6")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("l_Trigger6");
                cameraManager.CircuitTrigger[5].SetActive(true);
            }
            else if (gameObject.name == "l_Trigger7")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("l_Trigger7");
                cameraManager.CircuitTrigger[6].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger8")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger8");
                cameraManager.CircuitTrigger[7].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger9")
            {
                spikePad.loopMe = true;
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger9");
                cameraManager.CircuitTrigger[8].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger10")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger10");
                cameraManager.CircuitTrigger[9].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger11")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger11");
                cameraManager.CircuitTrigger[10].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger12")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger12");
                //cameraManager.CircuitTrigger[11].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger13")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger13");
                Box_Script.dropBox = true;
                //cameraManager.CircuitTrigger[12].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger14")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger14");
                cameraManager.CircuitTrigger[13].SetActive(true);
            }
            else if (gameObject.name == "c_Trigger15")
            {
                FindObjectOfType<MusicManager>().Play("CircuitSound");
                Destroy(gameObject);
                DestroyTrigger("c_Trigger15");
                circuitManager.PushBox2.GetComponent<BoxCollider>().enabled = true;
                cameraManager.CircuitTrigger[14].SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lockObj.SetActive(false);
            lockScript.EmptyLock();
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

    void CheckInteractableUI()
    {
        if (lockObj.activeInHierarchy)
        {
            circuitManager.InteractUI.SetActive(false);
        }
        else
        {
            circuitManager.InteractUI.SetActive(true);
        }
    }
}
