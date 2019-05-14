using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB1 : MonoBehaviour {

    public AudioSource playThis;

	void Start () {
        playThis = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "MB1_Plate")
            {
                playThis.Play();
                Destroy(GetComponent<MB1>());
            }
            else if (gameObject.name == "LowE1_Plate")
            {
                playThis.Play();
            }
        }
    }
}
