using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    /// <summary>
    /// Rmbr to add in circuitriggr GmObjt == trigger2
    /// circuitManager.PushBox.GetComponent<BoxCollider>().enabled = true;
    /// 
    /// rmbr tp rfrence in Circuitmanager, drag and drop
    /// public GameObject PushBox;
    /// </summary>

    public GameObject movingBox;

    public bool moveFor = false;

    void Start () {
        
    }

    private void Update()
    {
        if (moveFor)
        {
            if (movingBox.transform.position.z < 150)
            {
                movingBox.transform.position = new Vector3(movingBox.transform.position.x,
                                                    movingBox.transform.position.y,
                                                    movingBox.transform.position.z + Time.deltaTime * 5);
            }
        }
    }

}
	

