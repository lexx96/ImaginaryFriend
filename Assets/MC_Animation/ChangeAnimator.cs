using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour {

    public AnimatorOverrideController overRideController;

	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().player_Max_MovementSpeed = 10f;

            other.gameObject.GetComponent<Animator>().runtimeAnimatorController = overRideController;

            if (gameObject.name == "OverrideAnimator1")
            {
                other.gameObject.GetComponent<PlayerController>().UseRunMetalStep();
            }
            else if (gameObject.name == "OverrideAnimator2")
            {
                other.gameObject.GetComponent<PlayerController>().UseRunGrassStep();
            }
        }
    }
}
