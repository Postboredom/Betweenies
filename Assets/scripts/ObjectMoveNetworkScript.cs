using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObjectMoveNetworkScript : NetworkBehaviour {

    public GameObject batteryHoldPlace;
    AudioSource audioclip;
	// Use this for initialization
	void Start () {
        batteryHoldPlace = gameObject.transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void pullBox(GameObject box)
    {
        CmdPull(box);
    }

    void pushBox(GameObject box)
    {
        Debug.Log("pushBox inside");
        CmdPush(box);
    }

    void GrabBattery(GameObject battery)
    {
        CmdGrab(battery);
    }

    void Walking(GameObject character)
    {
        CmdWalk(character);
    }

    void StopWalk(GameObject character)
    {
        CmdStopWalk(character);
    }

    void Pushing(GameObject character)
    {
        CmdPushPull(character);
    }

    void OpenDoor(GameObject door)
    {
        CmdDoor(door);
    }

    void Spawnitem(GameObject item)
    {
        CmdEnable(item);
    }

    void colenable(GameObject item)
    {
        CmdEnablecol(item);
    }

    void Moveit(GameObject item)
    {
        CmdAnimate(item);
    }

    [Command]
    void CmdPull(GameObject box)
    {
        audioclip = box.GetComponent<AudioSource>();
        Vector3 towards = new Vector3(box.transform.position.x, box.transform.position.y, gameObject.transform.position.z + 1);
        box.transform.position = Vector3.MoveTowards(box.transform.position, towards, 0.1f);
        if (!audioclip.isPlaying)
        {
            audioclip.Play();
        }
    }

    [Command]
    void CmdPush(GameObject box)
    {
        audioclip = box.GetComponent<AudioSource>();
        Debug.Log("Command push inside");
        Vector3 towards = new Vector3(gameObject.transform.position.x+2.4f, box.transform.position.y, box.transform.position.z);
        box.transform.position = Vector3.MoveTowards(box.transform.position, towards, 0.1f);
        if (!audioclip.isPlaying)
        {
            audioclip.Play();
        }
    }

    [Command]
    void CmdGrab(GameObject bat)
    {
        Vector3 towards = new Vector3(gameObject.transform.Find("BatteryHoldPlace").position.x, gameObject.transform.Find("BatteryHoldPlace").position.y, gameObject.transform.Find("BatteryHoldPlace").position.z);
        bat.transform.position = Vector3.MoveTowards(bat.transform.position, towards, 0.1f);
        //bat.transform.parent = batteryHoldPlace.transform;
        bat.GetComponent<Rigidbody>().isKinematic = true;
        bat.GetComponent<Rigidbody>().useGravity = false;
        bat.GetComponent<CapsuleCollider>().enabled = false;
    }

    [Command]
    void CmdDoor(GameObject door)
    {
        audioclip = door.GetComponent<AudioSource>();
        Debug.Log("Destroying door");
        Destroy(door);
        if (!audioclip.isPlaying)
        {
            audioclip.Play();
        }
    }

    [Command]
    void CmdEnable(GameObject enabler)
    {
        enabler.SetActive(true);
    }

    [Command]
    void CmdEnablecol(GameObject enabler)
    {
        enabler.GetComponent<BoxCollider>().enabled = true;
    }

    [Command]
    void CmdAnimate(GameObject animator)
    {
        animator.GetComponent<Animator>().SetBool("open", true);
    }

    [Command]
    void CmdWalk(GameObject character)
    {
        character.GetComponent<Animator>().SetBool("iswalking", true);
    }

    [Command]
    void CmdPushPull(GameObject character)
    {
        character.transform.Find("HumanCharacter_Idle").gameObject.GetComponent<Animator>().SetBool("ispushing", true);
    }

    [Command]
    void CmdStopWalk(GameObject character)
    {
        character.GetComponent<Animator>().SetBool("iswalking", false);
    }
}
