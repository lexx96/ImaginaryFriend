using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject cinematicCamera;

    public GameObject EndScreenUI;
    public GameObject EndScreenObj;

    public GameObject Player;

    public float endTimer = 5f;
    public bool runTimer = false;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (runTimer)
        {
            endTimer -= Time.deltaTime;
            if (endTimer < 0)
            {
                Player.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            runTimer = true;
            EndScreenUI.SetActive(true);
            EndScreenObj.SetActive(true);
        }
    }
}
