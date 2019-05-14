using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStep : MonoBehaviour {

	void Start () {}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "GrassSteps")
            {
                other.GetComponent<PlayerController>().UseGrassStep();
            }
            else if (gameObject.name == "ConcreteSteps")
            {
                other.GetComponent<PlayerController>().UseConcreteStep();
            }
            else if(gameObject.name == "MetalSteps")
            {
                other.GetComponent<PlayerController>().UseMetalStep();
            }
            else if (gameObject.name == "LadderSteps")
            {
                other.GetComponent<PlayerController>().UseLadder();
            }
            else if (gameObject.name == "StairSteps")
            {
                other.GetComponent<PlayerController>().UseStair();
            }
        }
    }
}
