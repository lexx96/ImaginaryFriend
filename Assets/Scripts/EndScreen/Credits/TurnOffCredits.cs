using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCredits : MonoBehaviour {

    public GameObject MainMenuObj;

	void Start () {
		
	}

    public void OnBackPressed()
    {
        MainMenuObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
