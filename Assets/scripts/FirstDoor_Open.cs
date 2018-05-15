using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FirstDoor_Open : NetworkBehaviour {

    private GameObject server;
    private bool isOpenable;
	// Use this for initialization
	void Start () {
        isOpenable = false;
       

    }
	
	// Update is called once per frame
	void Update () {
        
		if (OVRInput.GetDown(OVRInput.RawButton.A, OVRInput.Controller.RTouch))
        {
            if (isOpenable)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Human_Player");
                player.SendMessage("OpenDoor", gameObject);
                Debug.Log("Sending message to open door");
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human_Player")
        {
            isOpenable = true;
        }
    }

}
