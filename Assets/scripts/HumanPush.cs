using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPush : MonoBehaviour {

    AudioSource audioclip;
    GameObject human;
    bool pushable;
    bool isPushed;
    // Use this for initialization
    void Start()
    {
        pushable = false;
        isPushed = false;
        audioclip = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pushable + " pushable");
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("inside fire1");
            if (pushable)
            {
                isPushed = !isPushed;
            }
        }
        if (isPushed)
        {
            Debug.Log("Sending push message");
          human.SendMessage("pushBox", gameObject); 
        }
        else
        {
            audioclip.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision entered");

        if (other.tag == "Human_Player")
        {
            Debug.Log("Human in right spot");
            human = other.gameObject;
            pushable = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Human_Player")
        {
            pushable = false;
            isPushed = false;
        }
    }

}
