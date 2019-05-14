using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewer_3_movement : MonoBehaviour {

    public GameObject gate;
    public bool gateDown = false;
    Vector3 openPosition = new Vector3(0, 7, 210);
    Vector3 closePosition = new Vector3(0, -7, 210);

    void Start () {}

    void Update ()
    {
        if (gateDown)
        {
            if (gate.transform.position.y <= 10)
            {
                gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - Time.deltaTime * -5, gate.transform.position.z);
                print(gate.transform.position);
            }
        }
        if (!gateDown)
        {
            if (gate.transform.position.y >= -10)
            {
                gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - Time.deltaTime * 5, gate.transform.position.z);
            }
        }
    }
}

