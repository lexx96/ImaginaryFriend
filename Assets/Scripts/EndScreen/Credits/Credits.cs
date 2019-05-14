using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public float endPosition;

    public float creditSpeed = 2f;

	void Start () {}
	
	void Update () {

        if (transform.position.y < endPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * creditSpeed, transform.position.z);
        }

        else if (transform.localPosition.y > 800f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
