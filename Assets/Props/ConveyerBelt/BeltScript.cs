using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScript : MonoBehaviour {

    public GameObject startPoint;
    public GameObject endPoint;
    public float verticalDisplacement;
    public float speed;

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Block"))
        {
            Vector3 newPosition = new Vector3(startPoint.transform.position.x, 
                                              startPoint.transform.position.y + verticalDisplacement, 
                                              startPoint.transform.position.z);

            transform.position = newPosition;
        }	
	}
}
