using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneManager : MonoBehaviour {

    public GameObject moveablePlatform;
    public GameObject downwardPlatform;

    public bool isMoving = false;
    public bool isGoingDown = false;

	void Start () {}
	
	void Update ()
    {
        if (isMoving)
        {
            if (moveablePlatform.transform.position.z < 670)
            {
                moveablePlatform.transform.position = new Vector3(moveablePlatform.transform.position.x,
                                                    moveablePlatform.transform.position.y,
                                                    moveablePlatform.transform.position.z + Time.deltaTime * 5);
            }
            //else
            //{
            //    isMoving = false;
            //}
        }
        else if (isGoingDown)
        {
            if (downwardPlatform.transform.position.y > -105.5f)
            {
                downwardPlatform.transform.position = new Vector3(downwardPlatform.transform.position.x,
                                                    downwardPlatform.transform.position.y - Time.deltaTime * 10,
                                                    downwardPlatform.transform.position.z);
            }
            //else
            //{
            //    isGoingDown = false;
            //}
        }
	}
}
