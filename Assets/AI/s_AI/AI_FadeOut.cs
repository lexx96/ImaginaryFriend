using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FadeOut : MonoBehaviour {

    public Material ObjMaterial;
    public Color MaterialColor;

    public bool FadeAway = false;

	void Start () {}

    void Update()
    {
        if (FadeAway)
        {
            if (MaterialColor.a > 0)
            {
                MaterialColor.a -= Time.deltaTime * 0.5f;
                ObjMaterial.color = MaterialColor;
            }
        }
        else
        {
            if (MaterialColor.a < 0.2)
            {
                MaterialColor.a += Time.deltaTime * 0.5f;
                ObjMaterial.color = MaterialColor;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicManager>().Play("Laugh");
            FadeAway = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FadeAway = false;
        }
    }
}
