using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHold : MonoBehaviour {

    bool grabbable;
    bool isGrabbed;
    bool isInserted;
    GameObject playerGrabbing;
	// Use this for initialization
	void Start () {
        grabbable = false;
        isGrabbed = false;
        isInserted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger, OVRInput.Controller.RTouch) && grabbable)
        {
            Debug.Log("inside fire2");
            Debug.Log(isGrabbed);
            isGrabbed = !isGrabbed;
        }
        if (isGrabbed && grabbable)
        {
            transform.position = playerGrabbing.transform.Find("BatteryHoldPlace").transform.position;
            Debug.Log("grabbing battery message");
            playerGrabbing.SendMessage("GrabBattery", gameObject);
        }
        else
        {
            if (isInserted)
            {
                isGrabbed = false;
                return;
            }
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if (gameObject.tag == "Battery_Inserted")
        {
            Collider a = gameObject.GetComponent<SphereCollider>();
            a.enabled = false;
        }
        if (gameObject.tag == "Battery_Inserted")
        {
            afterInsert();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInserted)
        {
            return;
        }
        if (other.tag == "Panel")
        {
            grabbable = false;
            Debug.Log("Close to panel");
            return;
        }
         else if (other.tag == "Dog_Player" || other.tag == "Human_Player")
        {
            Debug.Log(other.tag + " in battery range");
            playerGrabbing = other.gameObject;
            grabbable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isInserted)
        {
            return;
        }
        if (other.tag == "Dog_Player" || other.tag == "Human_Player")
        {
            Debug.Log(other.tag + " out of battery range");
            playerGrabbing = null;
            grabbable = false;
        }
    }

    private void afterInsert()
    {
        isInserted = true;
        Collider a = gameObject.GetComponent<Collider>();
        a.enabled = false;
        gameObject.transform.parent = null;
    }

}
