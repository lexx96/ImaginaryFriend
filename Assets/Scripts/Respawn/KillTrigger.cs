using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTrigger : MonoBehaviour {

    public bool isDying = false;

    public GameObject timerObj;
    public Text CountDownDeath;

    [Header("Death")]
    public GameObject deathUI;
    public GameObject deathTransition;

    [Header("AutoFill")]
    public Respawn respawn;
    public PlayerController playerController;

    public float deathTimer = 5f;

	void Start ()
    {
        respawn = GameObject.Find("RespawnCheckPoints").GetComponent<Respawn>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        timerObj.SetActive(false);
    }
	
	void Update ()
    {
        if (isDying)
        {
            deathTimer -= Time.deltaTime;
            CountDownDeath.text = deathTimer.ToString("");

            if (deathTimer < 0)
            {
                playerController.isDead = true;
                playerController.isKeyboardOn = false;
                playerController.MatchStick.SetActive(false);
                timerObj.SetActive(false);

                isDying = false;
            }
            else
            {
                playerController.isDead = false;
            }
        }
        else if (!isDying && !playerController.isDead)
        {
            deathTimer = 5f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerObj.SetActive(true);
            deathUI.SetActive(true);
            isDying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerObj.SetActive(false);
            deathUI.SetActive(false);
            isDying = false;
        }
    }
}
