using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour {

    public Move_Block move_Block;

	void Start ()
    {
        move_Block = GameObject.Find("Moving_Block").GetComponent<Move_Block>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Crate1"))
        {
            move_Block.box1 = true;
        }
        else if (other.gameObject.name.Equals("Crate2"))
        {
            move_Block.box2 = true;
        }
        else if (other.gameObject.name.Equals("Crate3"))
        {
            move_Block.box3 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Crate1"))
        {
            move_Block.box1 = false;
        }
        else if (other.gameObject.name.Equals("Crate2"))
        {
            move_Block.box2 = false;
        }
        else if (other.gameObject.name.Equals("Crate3"))
        {
            move_Block.box3 = false;
        }
    }
}
