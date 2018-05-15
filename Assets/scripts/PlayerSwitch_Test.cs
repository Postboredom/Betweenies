using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSwitch_Test : NetworkBehaviour {

    private GameObject simplePlayerModel;
    public GameObject dogModel;
    public GameObject humanModel;
    //private bool isHuman;
    public GameObject controller;

	// Use this for initialization
	void Start () {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        //isHuman = (isServer && isLocalPlayer);
        //simplePlayerModel = gameObject.transform.GetChild(1).gameObject;
        if (isServer && isLocalPlayer)
        {
            //Server host player is always the human
            gameObject.tag = "Human_Player";
            Debug.Log("I am human");
            dogModel.active = false;
            humanModel.active = false;
            controller.transform.localScale = new Vector3(.7f, .7f, .7f);
            //Renderer mat = simplePlayerModel.GetComponent<Renderer>();
            //mat.material = humanMat;
            //CharacterController hu = gameObject.GetComponent<CharacterController>();
            //hu.radius = 0.5f;
            //hu.center = new Vector3(0f, 0.05f, 0f);
            //hu.height = 2.0f;
            //Camera cam = gameObject.GetComponentInChildren<Camera>();
            //cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1, cam.transform.position.z);
        }
        else if (!isServer && isLocalPlayer)
        {
            humanModel.active = false;
            dogModel.active = false;
            controller.transform.localScale = new Vector3(.5f, .5f, .5f);
            //Server client player is always the dog
            gameObject.tag = "Dog_Player";
            Debug.Log("I am dog");
            //Renderer mat = simplePlayerModel.GetComponent<Renderer>();
            //mat.material = dogMat;
        }
        if (isServer && !isLocalPlayer)
        {
            gameObject.tag = "Dog_Player";
            Debug.Log("I am dog");
            humanModel.active = false;
            //Renderer mat = simplePlayerModel.GetComponent<Renderer>();
            //mat.material = dogMat;

        }
        else if (!isServer && !isLocalPlayer)
        {
            dogModel.active = false;
            gameObject.tag = "Human_Player";
            Debug.Log("I am human");

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
