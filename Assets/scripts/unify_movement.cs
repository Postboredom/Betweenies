using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class unify_movement : NetworkBehaviour  {

    public GameObject origin;
    public GameObject LeftHandOrigin;
    public GameObject RightHandOrigin;

    public GameObject LeftHandTarget;
    public GameObject RightHandTarget;
    void Start(){
        if(isLocalPlayer){

            if(origin == null){
                origin = GameObject.FindGameObjectWithTag("GameController");
            }
            if(LeftHandOrigin == null)
            {
                //LeftHandOrigin = GameObject.FindGameObjectWithTag("LeftHand");
            }
            if(RightHandOrigin == null)
            {
                //LeftHandOrigin = GameObject.FindGameObjectWithTag("RightHand");
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if(isLocalPlayer){

            Debug.Log("unifying movement");
            transform.position = origin.transform.position;
            transform.rotation = origin.transform.rotation;

            //LeftHandTarget.transform.position = LeftHandOrigin.transform.position;
            //LeftHandTarget.transform.rotation = LeftHandOrigin.transform.rotation;

            //RightHandTarget.transform.position = RightHandOrigin.transform.position;
            //RightHandTarget.transform.rotation = RightHandOrigin.transform.rotation;

        }

    }
}
