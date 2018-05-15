using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class frontDoor_Open : NetworkBehaviour {

    private bool dogTrigger = false;
    private bool humanTrigger = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (dogTrigger == true && humanTrigger == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Human_Player");
            player.SendMessage("Spawnitem", gameObject);
        }	
	}

    void humanOpen()
    {
        humanTrigger = true;
    }

    void dogOpen()
    {
        dogTrigger = true;
    }
}
