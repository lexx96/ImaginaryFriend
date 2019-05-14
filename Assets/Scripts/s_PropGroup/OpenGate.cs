using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    public Rigidbody Player;

    [Header("Auto Fill")]
    public Transform L_Pivot;
    public Transform R_Pivot;
    bool L_Open = false;
    bool R_Open = false;
    bool L_timer = false;
    bool R_timer = false;
    float L_Counter = 3;
    float R_Counter = 3;
    void Start()
    {
        L_Pivot = GameObject.Find("Left_Pivot").transform;
        R_Pivot = GameObject.Find("Right_Pivot").transform;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (L_Open)
        {
            L_Pivot.localEulerAngles -= new Vector3(0, Time.deltaTime * -Player.velocity.z, 0);
            if (L_timer)
            {
                L_Counter -= Time.deltaTime;
                if (L_Counter < 0)
                {
                    L_Counter = 3f;
                    L_Open = false;
                    L_timer = false;
                }
            }
        }

        if (R_Open)
        {
            R_Pivot.localEulerAngles += new Vector3(0, Time.deltaTime * Player.velocity.z, 0);
            if (R_timer)
            {
                R_Counter -= Time.deltaTime;
                if (R_Counter < 0)
                {
                    R_Counter = 3f;
                    R_Open = false;
                    R_timer = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "L_Door" && collision.gameObject.CompareTag("Player"))
        {
            L_Open = true;
        }

        if (gameObject.name == "R_Door" && collision.gameObject.CompareTag("Player"))
        {
            R_Open = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.name == "L_Door" && collision.gameObject.CompareTag("Player"))
        {
            L_timer = true;
        }

        if (gameObject.name == "R_Door" && collision.gameObject.CompareTag("Player"))
        {
            R_timer = true;
        }
    }
}
