using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class teleport : MonoBehaviour {
    GameObject Player;
    public Transform teleport_area;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human_Player")
        {
            Player = GameObject.FindGameObjectWithTag("GameController");
            Player.transform.position = teleport_area.position;
            Player.transform.rotation = teleport_area.rotation;
        }
    }
}
