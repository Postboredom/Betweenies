using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_walking : MonoBehaviour {
    CharacterController controller;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        var magnitude = controller.velocity.sqrMagnitude;
        if (magnitude < 0)
        {
            return;
        }
        else
        {
            gameObject.SendMessage("Walking", gameObject);
        }
    }
}
