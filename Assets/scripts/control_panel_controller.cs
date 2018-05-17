using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class control_panel_controller : NetworkBehaviour {

    //public GameObject[] bats;
    public GameObject toActivate;

    private int batsInserted;
    private int neededBatteries;
    private Collider interaction;
    private GameObject dogPlayer;

    public List<Transform> batteryPos;


	// Use this for initialization
	void Start () {
        interaction = GetComponent<BoxCollider>();
        batsInserted = 0;
        
        batteryPos = new List<Transform>();
        neededBatteries = 0;
        foreach (Transform child in transform)
        {
            if (child.tag == "Battery_Housing") {
                batteryPos.Add(child);
                neededBatteries += 1;
            }
        }

        if (toActivate.activeSelf)
        {
            toActivate.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Bats Inserted: " + batsInserted);

	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "battery")
        {
            Debug.Log("Battery Placed");
            int b = batsInserted;
            other.GetComponent<BatteryHold>().enabled = false;
            RpcBatteryPlace(other.gameObject);
            //other.transform.position = batteryPos[batsInserted].position;
            //other.transform.rotation = batteryPos[batsInserted].rotation;
            //other.tag = "Battery_Inserted";     //change the tag to avoid repeated checking
            //                                    //freeze position
            //other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            //other.gameObject.transform.parent = this.transform.parent;
            ////increase the counter
            //batsInserted++;

            //set bat to position of holder
            if (b == batsInserted)
            {
                other.tag = "Battery_Inserted";
            } 
        }
        //if we have all the batteries we need, activate the pressure plate object, turn off the collider
        if(batsInserted == neededBatteries)
        {
            
            toActivate.SetActive(true);
            interaction.enabled = false;
        }
    }

    [ClientRpc]
    void RpcBatteryPlace(GameObject bat)
    {
        Debug.Log("clientrpc call");
        bat.transform.position = batteryPos[batsInserted].position;
        bat.transform.rotation = batteryPos[batsInserted].rotation;
            //change the tag to avoid repeated checking
                                            //freeze position
        bat.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        bat.GetComponent<Rigidbody>().useGravity = false;
        bat.GetComponent<Rigidbody>().isKinematic = false;
        //bat.gameObject.transform.parent = this.transform.parent;
        //increase the counter
        batsInserted++;
        bat.tag = "Battery_Inserted";
    }
}
