using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTrigger : MonoBehaviour {

    [Header("AutoFill")]
    public CraneManager craneManager;

    void Start ()
    {
        craneManager = GameObject.Find("CraneManager").GetComponent<CraneManager>();

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (gameObject.name == "LeftRight")
            {
                collision.collider.gameObject.transform.parent = craneManager.moveablePlatform.transform;
                craneManager.isMoving = true;
            }
            else if (gameObject.name == "downward")
            {
                collision.collider.gameObject.transform.parent = craneManager.downwardPlatform.transform;
                craneManager.isGoingDown = true;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (gameObject.name == "LeftRight")
            {
                collision.collider.gameObject.transform.parent = null;
                craneManager.isMoving = false;
            }
            else if (gameObject.name == "downward")
            {
                collision.collider.gameObject.transform.parent = null;
                craneManager.isGoingDown = false;
            }
        }
    }
}
