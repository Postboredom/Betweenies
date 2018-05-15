using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpawnManager : NetworkBehaviour {

    public GameObject dogPrefab;
    public GameObject humanPrefab;
    public Vector3 spawnPos;
    bool which;
	// Use this for initialization
	void Start () {
        which = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if (!which)
        {
            Debug.Log("inside onserver add player");
            var player = (GameObject)GameObject.Instantiate(humanPrefab, spawnPos, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            which = true;
        } else
        {
            Debug.Log("dog spawn");
            var player = (GameObject)GameObject.Instantiate(dogPrefab, spawnPos, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        
    }
}
