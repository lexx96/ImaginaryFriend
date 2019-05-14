using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [Header("Factory Camera")]
    public GameObject[] f_CameraPosition;

    [Header("Circuit Trigger")]
    public GameObject[] CircuitTrigger;

    [Header("Kill Trigger")]
    public GameObject[] KillTrigger;

    public bool gameStarted = false;
    public GameObject startCameraPosition;

    [Header("Factory Camera Trigger")]
    public bool f_Cam1 = false;
    public bool f_Cam2 = false;
    public bool f_Cam3 = false;
    public bool f_Cam4 = false;
    public bool f_Cam5 = false;
    public bool f_Cam6 = false;
    public bool f_Cam7 = false;
    public bool f_Cam8 = false;
    public bool f_Cam9 = false;
    public bool f_Cam10 = false;
    public bool f_Cam11 = false;
    public bool f_Cam12 = false;
    public bool f_Cam13 = false;
    public bool f_Cam14 = false;
    public bool f_Cam15 = false;
    public bool f_Cam16 = false;
    public bool f_Cam17 = false;
    public bool f_Cam18 = false;

    public float h = 00;
    public float m = 00;
    public float s = 00;
    public int ms = 00;

    #region Public Variables
    [Header("Entrance Camera Trigger")]
    [HideInInspector]
    public bool e_Cam1 = true;
    [HideInInspector]
    public bool e_Cam2 = false;

    [Header("Entrance Camera")]
    public GameObject[] e_CameraPosition;

    [Header("Camera UI")]
    public GameObject CameraUI;

    [Header("Damping")]
    public float transitionDamping = 7.5f;
    public float rotationDamping = 0.75f;
    #endregion

    #region Auto Fill & Private Variables
    Vector3 relativePosition;
    Quaternion targetRotation;

    [Header("Turn Off Objects")]
    public GameObject[] Obj2Off;
    public UIScript uIScript;

    [Header("Auto Fill")]
    [HideInInspector]
    public GameObject Player;
    [HideInInspector]
    public PlayerController player_Controller;
    [HideInInspector]
    public GameObject CameraObj;
    [HideInInspector]
    public CameraView cameraView;

    #endregion

    #region Start & Awake
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        player_Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraView = GameObject.Find("ViewTriggers").GetComponent<CameraView>();
    }
    #endregion

    void Update()
    {
        if (gameStarted)
        {
            #region Camera Timer
            ms += (int)Time.time;

            if (ms > 60)
            {
                ++s;
                ms = 0;
            }
            if (s > 60)
            {
                ++m;
                s = 0;
            }
            else if (m > 60)
            {
                ++h;
                m = 0;
            }
            #endregion

            Player.GetComponent<PlayerController>().enabled = true;

            #region Entrance Camera
            if (e_Cam1)
            {
                CameraObj.transform.SetParent(e_CameraPosition[0].transform);

                float Dist = Vector3.Distance(CameraObj.transform.position, e_CameraPosition[0].transform.position);

                if (Dist > 0.05f)
                {
                    CameraObj.transform.position = Vector3.Lerp(CameraObj.transform.position, e_CameraPosition[0].transform.position, Time.deltaTime * transitionDamping);
                    CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, e_CameraPosition[0].transform.rotation, Time.deltaTime * transitionDamping);
                }
                else if (Dist < 0.05f)
                {
                    relativePosition = Player.transform.position - CameraObj.transform.position;
                    targetRotation = Quaternion.LookRotation(relativePosition);
                    CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, targetRotation, Time.deltaTime * rotationDamping);

                    CameraObj.transform.position = e_CameraPosition[0].transform.position;
                }
            }

            if (e_Cam2)
            {
                CameraObj.transform.SetParent(e_CameraPosition[1].transform);

                float Dist = Vector3.Distance(CameraObj.transform.position, e_CameraPosition[1].transform.position);

                if (Dist > 0.05)
                {
                    CameraObj.transform.position = Vector3.Lerp(CameraObj.transform.position, e_CameraPosition[1].transform.position, Time.deltaTime * transitionDamping);
                    CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, e_CameraPosition[1].transform.rotation, Time.deltaTime * transitionDamping);
                }
                else if (Dist < 0.05)
                {
                    CameraObj.transform.position = e_CameraPosition[1].transform.position;

                    relativePosition = Player.transform.position - CameraObj.transform.position;
                    targetRotation = Quaternion.LookRotation(relativePosition);
                    CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, targetRotation, Time.deltaTime * rotationDamping);
                }
            }
            #endregion

            #region Factory Camera
            if (f_Cam1)
            {
                uIScript.cameraNumber.text = "Cam 001";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[0].transform.position, f_CameraPosition[0].transform.rotation, f_CameraPosition[0].transform, true);
            }
            else if (f_Cam2)
            {
                uIScript.cameraNumber.text = "Cam 002";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[1].transform.position, f_CameraPosition[1].transform.rotation, f_CameraPosition[1].transform, true);
            }
            else if (f_Cam3)
            {
                uIScript.cameraNumber.text = "Cam 003";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[2].transform.position, f_CameraPosition[2].transform.rotation, f_CameraPosition[2].transform, true);
            }
            else if (f_Cam4)
            {
                uIScript.cameraNumber.text = "Cam 004";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[3].transform.position, f_CameraPosition[3].transform.rotation, f_CameraPosition[3].transform, true);
            }
            else if (f_Cam5)
            {
                uIScript.cameraNumber.text = "Cam 005";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[4].transform.position, f_CameraPosition[4].transform.rotation, f_CameraPosition[4].transform, true);
            }
            else if (f_Cam6)
            {
                uIScript.cameraNumber.text = "Cam 006";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[5].transform.position, f_CameraPosition[5].transform.rotation, f_CameraPosition[5].transform, true);
            }
            else if (f_Cam7)
            {
                uIScript.cameraNumber.text = "Cam 007";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[6].transform.position, f_CameraPosition[6].transform.rotation, f_CameraPosition[6].transform, true);
            }
            else if (f_Cam8)
            {
                uIScript.cameraNumber.text = "Cam 008";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[7].transform.position, f_CameraPosition[7].transform.rotation, f_CameraPosition[7].transform, true);
            }
            else if (f_Cam9)
            {
                uIScript.cameraNumber.text = "Cam 009";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[8].transform.position, f_CameraPosition[8].transform.rotation, f_CameraPosition[8].transform, true);
            }
            else if (f_Cam10)
            {
                uIScript.cameraNumber.text = "Cam 010";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[9].transform.position, f_CameraPosition[9].transform.rotation, f_CameraPosition[9].transform, true);
            }
            else if (f_Cam11)
            {
                uIScript.cameraNumber.text = "Cam 011";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[10].transform.position, f_CameraPosition[10].transform.rotation, f_CameraPosition[10].transform, true);
            }
            else if (f_Cam12)
            {
                uIScript.cameraNumber.text = "Cam 012";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[11].transform.position, f_CameraPosition[11].transform.rotation, f_CameraPosition[11].transform, true);
            }
            else if (f_Cam13)
            {
                uIScript.cameraNumber.text = "Cam 013";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[12].transform.position, f_CameraPosition[12].transform.rotation, f_CameraPosition[12].transform, true);
            }
            else if (f_Cam14)
            {
                uIScript.cameraNumber.text = "Cam 014";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[13].transform.position, f_CameraPosition[13].transform.rotation, f_CameraPosition[13].transform, true);
            }
            else if (f_Cam15)
            {
                uIScript.cameraNumber.text = "Cam 015";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[14].transform.position, f_CameraPosition[14].transform.rotation, f_CameraPosition[14].transform, true);
            }
            else if (f_Cam16)
            {
                uIScript.cameraNumber.text = "Cam 016";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[15].transform.position, f_CameraPosition[15].transform.rotation, f_CameraPosition[15].transform, true);
            }
            else if (f_Cam17)
            {
                uIScript.cameraNumber.text = "Cam 017";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[16].transform.position, f_CameraPosition[16].transform.rotation, f_CameraPosition[16].transform, true);
            }
            else if (f_Cam18)
            {
                uIScript.cameraNumber.text = "Cam 018";
                uIScript.cameraTime.text = string.Format("{0}:{1}:{2}:{3}", h.ToString("00"), m.ToString("00"), s.ToString("00"), ms.ToString("00"));
                CurrentCameraView(f_CameraPosition[17].transform.position, f_CameraPosition[17].transform.rotation, f_CameraPosition[17].transform, true);
            }
            #endregion
        }
        else
        {
            Player.GetComponent<PlayerController>().enabled = false;

            CameraObj.transform.position = startCameraPosition.transform.position;
            CameraObj.transform.rotation = startCameraPosition.transform.rotation;
        }
    }

    #region CurrentCameraView Method
    public void CurrentCameraView(Vector3 targetPosition, Quaternion targetRotation, Transform targetParent, bool isCameraOn)
    {
        CameraObj.transform.position = targetPosition;
        CameraObj.transform.rotation = targetRotation;

        CameraObj.transform.SetParent(targetParent);

        if (isCameraOn)
        {
            CameraUI.SetActive(true);
        }
        else
            CameraUI.SetActive(false);
    }
    #endregion
}
