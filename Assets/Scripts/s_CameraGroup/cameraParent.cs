using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraParent : MonoBehaviour {
    [Header("Auto Fill")]
    public Transform playerTransform;

	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	void Update () {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
    }
}
