using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {

    public GameObject Platform1;

    public bool move_Platform1 = false;

	void Update ()
    {
        if (move_Platform1)
        {
            if (Platform1.transform.position.y < 5)
            {
                Platform1.transform.position += new Vector3(0, Time.deltaTime * 2f, 0);
            }
        }
        else if (!move_Platform1)
        {
            if (Platform1.transform.position.y > -0.375)
            {
                Platform1.transform.position += new Vector3(0, -Time.deltaTime * 2f, 0);
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move_Platform1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move_Platform1 = false;
        }
    }
}
