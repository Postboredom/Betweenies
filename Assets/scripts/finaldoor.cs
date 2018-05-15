using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finaldoor : MonoBehaviour {

    public GameObject door;
    public GameObject key;
    private void Start()
    {
        key = GameObject.FindGameObjectWithTag("key");
    }
    private void OnTriggerEnter(Collider other)
    {
        key = GameObject.FindGameObjectWithTag("key");
        if (key.activeSelf == false)
        {
            Destroy(this.gameObject);
            Destroy(door.gameObject);
        }
    }
}
