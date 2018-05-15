using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class holding : NetworkBehaviour {
    bool pickup = false;
    GameObject currentBattery;
	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "battery" && pickup == false)
        {
            currentBattery = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "battery")
        {
            currentBattery = null;
        }
        if (other.GetComponent<Rigidbody>() != null && pickup == true)
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            pickup = false;
            return;
        }
    }

    void Update () {
        if (Input.GetButtonDown("Fire2") && pickup == false)
        {
            if (currentBattery != null)
            {
                Debug.Log(currentBattery.tag);
                CmdBatteryMove(currentBattery);
            }
        } else if (pickup == true)
        {
            CmdBatteryDrop(currentBattery);
        }
	}

    [Command]
    void CmdBatteryMove(GameObject bat)
    {
        bat.GetComponent<Rigidbody>().isKinematic = false;
        pickup = false;
        bat.transform.parent = null;
    }

    [Command]
    void CmdBatteryDrop(GameObject bat)
    {
        bat.GetComponent<Rigidbody>().isKinematic = true;
        pickup = true;
        bat.transform.parent = this.gameObject.transform;
    }
}