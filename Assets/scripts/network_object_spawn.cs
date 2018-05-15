using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

 class network_object_spawn : NetworkBehaviour {

    public GameObject[] spawn;
    public Transform[] locations;
    private void Start()
    {
        Debug.Log(isServer + " is Server");
        Setup();
    }
    private void Setup()
    {
        
        if (isServer)
        {
            for (int ii = 0; ii < spawn.Length; ii++)
            {
                GameObject newspawn = (GameObject)Instantiate(spawn[ii], locations[ii].position, locations[ii].rotation);
                NetworkServer.Spawn(newspawn);
            }
        }
       
    }
}
