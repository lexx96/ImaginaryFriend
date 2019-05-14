using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour {

    #region AutoFill
    [Header("AutoFill")]
    public GameObject Player;
    public Respawn respawn;
    public PlayerController playerController;
    #endregion

    #region Start & Awake
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.Find("RespawnCheckPoints").GetComponent<Respawn>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    #endregion

    public void IsDead()
    {
        Player.transform.position = respawn.respawningHere.position;
        playerController.isDead = false;
        playerController.isKeyboardOn = true;
        playerController.MatchStick.SetActive(true);
    }

    public void SelfOff()
    {
        gameObject.SetActive(false);
    }
}
