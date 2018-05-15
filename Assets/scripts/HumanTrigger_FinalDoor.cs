using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HumanTrigger_FinalDoor : NetworkBehaviour
{

    private bool doorOpenable = false;
    public GameObject door;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human_Player")
        {
            setDoorOpenable();
            Debug.Log("Human is on pressure plate");
            doorOpen();
        }
    }

    private void setDoorOpenable()
    {
        doorOpenable = true;
    }

    private void doorOpen()
    {
        door.SendMessage("humanOpen");
    }
}