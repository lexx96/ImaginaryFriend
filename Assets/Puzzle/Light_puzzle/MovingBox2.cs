using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox2 : MonoBehaviour {

    /// <summary>
    /// Rmbr to add in circuitriggr GmObjt == trigger15
    /// circuitManager.PushBox2.GetComponent<BoxCollider>().enabled = true;
    /// 
    /// rmbr to rfrence in Circuitmanager, drag and drop
    /// public GameObject PushBox2
    /// public GameObject[] LightTriggers (L1,L2,L3,L4)
    /// public GameObject[] Emptyboxes; (E1,E2,E3)
    /// 
    /// rmbr to rfrence in movingbox2 & pushtrigger2.pushbox2
    /// public Gameobject Movingbox2
    /// </summary>

    public GameObject movingBox2;

    public bool moveFor2 = false;

    void Start()
    {

    }

    private void Update()
    {
        if (moveFor2)
        {
            if (movingBox2.transform.localPosition.x < 1.5)
            {
                movingBox2.transform.position = new Vector3(movingBox2.transform.position.x + Time.deltaTime * 5,
                                                    movingBox2.transform.position.y,
                                                    movingBox2.transform.position.z);
            }
        }
    }
}
