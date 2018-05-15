using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class box_mover : MonoBehaviour {
    public GameObject box;
    public GameObject box2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human_Player")
        {
            other.gameObject.SendMessage("colenable", box);
            other.gameObject.SendMessage("colenable", box2);
        }
    }
}
