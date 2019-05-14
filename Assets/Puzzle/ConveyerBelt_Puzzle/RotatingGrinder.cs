using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingGrinder : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (gameObject.name == "R_Out")
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 20f);
        }

        if (gameObject.name == "R_In")
        {
            transform.Rotate(Vector3.right * -Time.deltaTime * 20f);
        }
    }
}
