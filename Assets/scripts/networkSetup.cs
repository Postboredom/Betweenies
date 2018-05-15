using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class networkSetup : NetworkBehaviour {
    public GameObject[] toDisable;
    
	// Use this for initialization
	void Start () {
       
        Debug.Log("in network setup " + isLocalPlayer);
        if (!isLocalPlayer)
        {
            Debug.Log("and I'm localplayer " + isLocalPlayer);

           foreach (GameObject item in toDisable)
            {

                item.SetActive(false);
            }
        }
        
	}
	
	
}
