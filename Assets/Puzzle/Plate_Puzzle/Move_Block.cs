using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Block : MonoBehaviour {

    public CameraManager cameraManager;
    AudioSource movingRock;

    public bool box1 = false;
    public bool box2 = false;
    public bool box3 = false;

    void Start ()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        movingRock = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if (box1 && box2 && box3)
        {
            cameraManager.CircuitTrigger[11].SetActive(true);
            FindObjectOfType<MusicManager>().Play("CircuitSound");
            if (transform.localPosition.z < 464.37)
            {
                movingRock.Play();
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 5f);
            }
            else
            {
                movingRock.Stop();
            }
        }
	}
}
