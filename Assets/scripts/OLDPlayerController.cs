using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class OLDPlayerController : NetworkBehaviour{

    public Camera cam; // Drag camera into here

    void Start()
    {
        // IF I'M THE PLAYER, STOP HERE (DON'T TURN MY OWN CAMERA OFF)
        if (isLocalPlayer) return;

        // DISABLE CAMERA AND CONTROLS HERE (BECAUSE THEY ARE NOT ME)
        cam.enabled = false;
        //GetComponent<PlayerControls>().enabled = false;
        //GetComponent<PlayerMovement>().enabled = false;
    }

	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

//        float x = Input.GetAxis("Horizontal");
//        float z = Input.GetAxis("Vertical");
//
//        transform.Rotate(0, x * 3, 0);
//
//        transform.Translate(0, 0, z);
        
	}
}
