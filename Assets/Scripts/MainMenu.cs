
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject StartMenuUIParent;
    public GameObject OpeningStatic;
    public CameraManager cameraManager;
    public GameObject CreditsObj;
    [Header("TurnOff")]
    public GameObject KeyUI;
    public GameObject AI_Waving;

    void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        CreditsObj.SetActive(false);
        //KeyUI.SetActive(true);
        StartMenuUIParent.SetActive(true);
        OpeningStatic.SetActive(true);
    }

    public void OnStartPressed()
    {
        //KeyUI.SetActive(true);
        Destroy(AI_Waving);
        CreditsObj.SetActive(false);
        StartMenuUIParent.SetActive(false);
        OpeningStatic.SetActive(false);
        cameraManager.gameStarted = true;
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnCreditsPressed()
    {
        CreditsObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
