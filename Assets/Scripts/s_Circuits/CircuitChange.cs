using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitChange : MonoBehaviour {

    #region Auto Fill & Private Variables
    [Header("Auto Fill")]
    public CameraManager cameraManager;
    public CameraView cameraView;
    public Respawn respawn;
    #endregion

    void Start()
    {
        cameraView = GameObject.Find("ViewTriggers").GetComponent<CameraView>();
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        respawn = GameObject.Find("RespawnCheckPoints").GetComponent<Respawn>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "CircuitChange1" && other.CompareTag("Player"))
        {
            cameraManager.h = 02;
            respawn.respawningHere = respawn.respawnPositions[1];
            cameraManager.f_Cam1 = false;
            cameraManager.KillTrigger[0].SetActive(true);
            cameraManager.KillTrigger[1].SetActive(false);
            cameraManager.f_Cam2 = true;
        }
        else if(gameObject.name == "CircuitChange2" && other.CompareTag("Player"))
        {
            cameraManager.h = 04;
            respawn.respawningHere = respawn.respawnPositions[2];
            cameraManager.f_Cam2 = false;
            cameraManager.KillTrigger[1].SetActive(true);
            cameraManager.KillTrigger[2].SetActive(false);
            cameraManager.f_Cam3 = true;
        }
        else if(gameObject.name == "CircuitChange3" && other.CompareTag("Player"))
        {
            cameraManager.h = 06;
            respawn.respawningHere = respawn.respawnPositions[3];
            cameraManager.f_Cam3 = false;
            cameraManager.KillTrigger[2].SetActive(true);
            cameraManager.KillTrigger[3].SetActive(false);
            cameraManager.f_Cam4 = true;
        }
        else if(gameObject.name == "CircuitChange4" && other.CompareTag("Player"))
        {
            cameraManager.h = 01;
            respawn.respawningHere = respawn.respawnPositions[4];
            cameraManager.f_Cam4 = false;
            cameraManager.KillTrigger[3].SetActive(true);
            cameraManager.KillTrigger[4].SetActive(false);
            cameraManager.f_Cam5 = true;
        }
        else if(gameObject.name == "CircuitChange5" && other.CompareTag("Player"))
        {
            cameraManager.h = 03;
            respawn.respawningHere = respawn.respawnPositions[5];
            cameraManager.f_Cam5 = false;
            cameraManager.KillTrigger[4].SetActive(true);
            cameraManager.KillTrigger[5].SetActive(false);
            cameraManager.f_Cam6 = true;
        }
        else if(gameObject.name == "CircuitChange6" && other.CompareTag("Player"))
        {
            cameraManager.h = 07;
            respawn.respawningHere = respawn.respawnPositions[6];
            cameraManager.f_Cam6 = false;
            cameraManager.KillTrigger[5].SetActive(true);
            cameraManager.KillTrigger[6].SetActive(false);
            cameraManager.f_Cam7 = true;
        }
        else if(gameObject.name == "CircuitChange7" && other.CompareTag("Player"))
        {
            cameraManager.h = 04;
            respawn.respawningHere = respawn.respawnPositions[7];
            cameraManager.f_Cam7 = false;
            cameraManager.KillTrigger[6].SetActive(true);
            cameraManager.KillTrigger[7].SetActive(false);
            cameraManager.f_Cam8 = true;
        }
        else if(gameObject.name == "CircuitChange8" && other.CompareTag("Player"))
        {
            cameraManager.h = 02;
            respawn.respawningHere = respawn.respawnPositions[8];
            cameraManager.f_Cam8 = false;
            cameraManager.KillTrigger[7].SetActive(true);
            cameraManager.KillTrigger[8].SetActive(false);
            cameraManager.f_Cam9 = true;
        }
        else if (gameObject.name == "CircuitChange9" && other.CompareTag("Player"))
        {
            cameraManager.h = 09;
            respawn.respawningHere = respawn.respawnPositions[9];
            cameraManager.f_Cam9 = false;
            cameraManager.KillTrigger[8].SetActive(true);
            cameraManager.KillTrigger[9].SetActive(false);
            cameraManager.f_Cam10 = true;
        }
        else if (gameObject.name == "CircuitChange10" && other.CompareTag("Player"))
        {
            cameraManager.h = 04;
            respawn.respawningHere = respawn.respawnPositions[10];
            cameraManager.f_Cam10 = false;
            cameraManager.KillTrigger[9].SetActive(true);
            cameraManager.KillTrigger[10].SetActive(false);
            cameraManager.f_Cam11 = true;
        }
        else if (gameObject.name == "CircuitChange11" && other.CompareTag("Player"))
        {
            cameraManager.h = 07;
            respawn.respawningHere = respawn.respawnPositions[11];
            cameraManager.f_Cam11 = false;
            cameraManager.KillTrigger[10].SetActive(true);
            cameraManager.KillTrigger[11].SetActive(false);
            cameraManager.f_Cam12 = true;
        }
        else if (gameObject.name == "CircuitChange12" && other.CompareTag("Player"))
        {
            cameraManager.h = 09;
            respawn.respawningHere = respawn.respawnPositions[12];
            cameraManager.f_Cam12 = false;
            cameraManager.KillTrigger[11].SetActive(true);
            cameraManager.KillTrigger[12].SetActive(false);
            cameraManager.f_Cam13 = true;
        }
        else if (gameObject.name == "CircuitChange13" && other.CompareTag("Player"))
        {
            cameraManager.h = 01;
            respawn.respawningHere = respawn.respawnPositions[13];
            cameraManager.f_Cam13 = false;
            cameraManager.KillTrigger[12].SetActive(true);
            cameraManager.KillTrigger[13].SetActive(false);
            cameraManager.f_Cam14 = true;
        }
        else if (gameObject.name == "CircuitChange14" && other.CompareTag("Player"))
        {
            cameraManager.h = 03;
            respawn.respawningHere = respawn.respawnPositions[14];
            cameraManager.f_Cam14 = false;
            cameraManager.KillTrigger[13].SetActive(true);
            cameraManager.KillTrigger[14].SetActive(false);
            cameraManager.f_Cam15 = true;
        }
        else if (gameObject.name == "CircuitChange15" && other.CompareTag("Player"))
        {
            cameraManager.h = 05;
            respawn.respawningHere = respawn.respawnPositions[15];
            cameraManager.f_Cam15 = false;
            cameraManager.KillTrigger[14].SetActive(true);
            cameraManager.KillTrigger[15].SetActive(false);
            cameraView.smoothToSideView = true;
        }
        else if (gameObject.name == "CircuitChange16" && other.CompareTag("Player"))
        {
            cameraManager.h = 07;
            respawn.respawningHere = respawn.respawnPositions[16];
            cameraManager.f_Cam15 = false;
            cameraView.smoothToSideView = false;
            cameraManager.f_Cam16 = true;
            cameraManager.KillTrigger[15].SetActive(true);
            cameraManager.KillTrigger[16].SetActive(false);
            //cameraManager.KillTrigger[16].SetActive(false);
            //cameraManager.f_Cam17 = true;
        }
        else if (gameObject.name == "CircuitChange17" && other.CompareTag("Player"))
        {
            cameraManager.h = 09;
            cameraManager.f_Cam16 = false;
            cameraManager.KillTrigger[16].SetActive(true);
            cameraManager.KillTrigger[17].SetActive(false);
            cameraManager.f_Cam17 = true;
        }
        else if (gameObject.name == "CircuitChange18" && other.CompareTag("Player"))
        {
            cameraManager.h = 03;
            respawn.respawningHere = respawn.respawnPositions[17];
            cameraManager.f_Cam17 = false;
            cameraManager.KillTrigger[17].SetActive(true);
            cameraManager.KillTrigger[18].SetActive(false);
            cameraManager.f_Cam18 = true;
        }
        else if (gameObject.name == "CircuitChange19" && other.CompareTag("Player"))
        {
            cameraManager.h = 05;
            respawn.respawningHere = respawn.respawnPositions[18];
            cameraManager.f_Cam18 = false;
            cameraManager.KillTrigger[18].SetActive(true);
            cameraView.smoothToSideView = true;
        }
    }
}
