using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    private bool finishedBelt;
    private float beltSpeed;

	void Start ()
    {
        finishedBelt = false;
	}
	
	void Update ()
    {
		
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.tag.Equals("Belt") && !finishedBelt)
        {
            transform.parent = collision.transform;
            beltSpeed = collision.gameObject.GetComponent<BeltScript>().speed;
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        if(other.transform.tag.Equals("Block"))
        {
            transform.parent = null;
            finishedBelt = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(beltSpeed,1,0), ForceMode.Impulse);
            //GetComponent<Rigidbody>().Sleep();
            //GetComponent<Collider>().enabled = false;
        }
	}
}
