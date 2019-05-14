using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour {

    public GameObject Player;
    public float pushSpeed = 5f;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            print(collision.gameObject.name);
            Player.transform.position += new Vector3(0, 0, Time.deltaTime * pushSpeed);
        }
    }
}
