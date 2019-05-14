using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTrigger : MonoBehaviour {

    public GameObject TorchLightObj;
    public GameObject AI_BeckoningOBJ;
    public GameObject KeyUI;

    #region Auto Fill & Private Variables
    [Header("Auto Fill")]
    public CameraManager cinematicCamera;
    public GameObject _ShuttleDoor;
    public Respawn respawn;

    bool closeShuttle = false;
    #endregion

    #region Start & Awake
    void Start ()
    {
        cinematicCamera = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        _ShuttleDoor = GameObject.Find("ShuttleDoor");
        respawn = GameObject.Find("RespawnCheckPoints").GetComponent<Respawn>();
    }
    #endregion

    #region Update
    void Update()
    {
        if (closeShuttle)
        {
            if (_ShuttleDoor.transform.localPosition.y > 5.5f)
            {
                _ShuttleDoor.transform.localPosition -= new Vector3(0, Time.deltaTime * 10f, 0);
                cinematicCamera.Obj2Off[0].SetActive(false);
            }
            else
            {
                closeShuttle = false;
            }
        }
    }
    #endregion

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Equals("f_Trigger1") && other.CompareTag("Player"))
        {
            TorchLightObj.SetActive(false);
            Destroy(AI_BeckoningOBJ);
            closeShuttle = true;
            KeyUI.SetActive(true);
            respawn.respawningHere = respawn.respawnPositions[0];

            cinematicCamera.e_Cam2 = false;
            cinematicCamera.f_Cam1 = true;
        }
    }
}
