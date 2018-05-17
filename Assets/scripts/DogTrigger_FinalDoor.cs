using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DogTrigger_FinalDoor : NetworkBehaviour
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
        if (other.gameObject.CompareTag("Dog_Player"))
        {
            setDoorOpenable();
            Debug.Log("Dog is on pressure plate");
            doorOpen();
        }
    }

    private void setDoorOpenable()
    {
        doorOpenable = true;
    }

    private void doorOpen()
    {
        transform.root.gameObject.SendMessage("dogOpen");
    }
}
