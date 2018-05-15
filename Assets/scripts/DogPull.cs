using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DogPull : NetworkBehaviour {

    GameObject dog;
    bool pullable;
    bool isPulled;
    Vector3 distance_ratio;
    NetworkConnection dogConn;
    NetworkIdentity net;
    AudioSource audioclip;

    // Use this for initialization
    void Start () {
        pullable = false;
        isPulled = false;
        audioclip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(pullable + " pullable");
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("inside fire1");   
            if (pullable)
            {
                isPulled = !isPulled;
            }
        }
        if (isPulled)
        {
            PullMove();
        }
        else
        {
            audioclip.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision entered");

        if (other.tag == "Dog_Player")
        {
            Debug.Log("Dog in right spot");
            dog = other.gameObject;
            pullable = true;
            
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dog_Player")
        {
            pullable = false;
            isPulled = false;
        }
    }

    private void PullMove()
    {
        dog.SendMessage("pullBox", gameObject);
        
    }

}
