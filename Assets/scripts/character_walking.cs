using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_walking : MonoBehaviour {
    CharacterController controller;
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("OVRPlayerController").GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        var magnitude = controller.velocity.sqrMagnitude;
        Debug.Log(magnitude);
        if (magnitude > 0)
        {       
       transform.root.gameObject.SendMessage("Walking", gameObject);
        }
        else
        {
            transform.root.gameObject.SendMessage("Walking", gameObject);

            Debug.Log("trying");
            transform.root.gameObject.SendMessage("StopWalk", gameObject);
        }
    }
}
