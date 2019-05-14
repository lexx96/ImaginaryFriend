using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4_spikePad : MonoBehaviour {

    public GameObject spike;
    public bool loopMe = false;
   
	void Start () {}

    void Update()
    {
        if (loopMe)
        {
            if (spike.transform.position.y > -1.60)
            {
                spike.transform.position = new Vector3(spike.transform.position.x, spike.transform.position.y - Time.deltaTime * 5, spike.transform.position.z);
            }
        }
    }
}
