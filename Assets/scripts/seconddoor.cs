using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seconddoor : MonoBehaviour {
    int counter = 0;
    public GameObject door;
    public GameObject key;
    public Transform spawn;
    GameObject[] peices;
    private void Start()
    {
        peices = GameObject.FindGameObjectsWithTag("Pressure Plate obj");
        key = GameObject.FindGameObjectWithTag("key");
        key.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        peices = GameObject.FindGameObjectsWithTag("Pressure Plate obj");
        if (peices.Length == 0)
        {
            Destroy(door.gameObject);
        }
        key.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        key.SetActive(true);
    }
}
