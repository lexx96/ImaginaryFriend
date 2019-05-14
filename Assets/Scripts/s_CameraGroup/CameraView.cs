using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    public PlayerController player_Controller;

    public GameObject _3rdPersonView;
    public GameObject _SideScrollerView;
    public GameObject _TopDownView;

    public bool smoothTo3rdPerson = false;
    public bool smoothToSideView = false;
    public bool smoothToTopDown = false;

    public float cameraDamping = 5f;

    [Header("Auto Fill")]
    public GameObject CameraObj;
    public GameObject _SideViewCamera;
    public GameObject _3rdPersonCamera;
    public GameObject _TopDownCamera;

    void Start()
    {
        player_Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        _SideViewCamera = GameObject.Find("SideViewCamera");
        _3rdPersonCamera = GameObject.Find("3rdPersonCamera");
        _TopDownCamera = GameObject.Find("TopDownCamera");

        //player_Controller.wsReady = true;
        //player_Controller.wsForward = true;
    }

    void Update()
    {
        #region 3rd Person View
        if (smoothTo3rdPerson)
        {
            CameraObj.transform.position = Vector3.Lerp(CameraObj.transform.position, _3rdPersonCamera.transform.position, Time.deltaTime * cameraDamping);
            CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, _3rdPersonCamera.transform.rotation, Time.deltaTime * cameraDamping);

            CameraObj.transform.SetParent(_3rdPersonCamera.transform);

            float Dist = Vector3.Distance(CameraObj.transform.position, _3rdPersonCamera.transform.position);

            if (Dist < 0.05)
            {
                CameraObj.transform.position = _3rdPersonCamera.transform.position;
                smoothTo3rdPerson = false;
            }
        }
        #endregion

        #region Top Down View
        if (smoothToTopDown)
        {
            CameraObj.transform.position = Vector3.Lerp(CameraObj.transform.position, _TopDownCamera.transform.position, Time.deltaTime * cameraDamping);
            CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, _TopDownCamera.transform.rotation, Time.deltaTime * cameraDamping);

            CameraObj.transform.SetParent(_TopDownCamera.transform);

            float Dist = Vector3.Distance(CameraObj.transform.position, _TopDownCamera.transform.position);

            if (Dist < 0.05)
            {
                CameraObj.transform.position = _TopDownCamera.transform.position;
                smoothToTopDown = false;
            }
        }
        #endregion

        #region Side Scrolling View
        if (smoothToSideView)
        {
            //CameraObj.transform.position = Vector3.Lerp(CameraObj.transform.position, _SideViewCamera.transform.position, Time.deltaTime * cameraDamping);
            //CameraObj.transform.rotation = Quaternion.Lerp(CameraObj.transform.rotation, _SideViewCamera.transform.rotation, Time.deltaTime * cameraDamping);

            CameraObj.transform.SetParent(_SideViewCamera.transform);

            //float Dist = Vector3.Distance(CameraObj.transform.position, _SideViewCamera.transform.position);

            CameraObj.transform.position = _SideViewCamera.transform.position;
            CameraObj.transform.rotation = _SideViewCamera.transform.rotation;

            //if (Dist < 0.05)
            //{
            //    CameraObj.transform.position = _SideViewCamera.transform.position;
            //    smoothToSideView = false;
            //}
        }
        #endregion
    }
}
