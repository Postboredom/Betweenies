using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class animation_hatch : NetworkBehaviour
{
    public GameObject hatch_right;
    public GameObject hatch_left;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Human_Player")
        {
            other.gameObject.SendMessage("Moveit", hatch_right);
            other.gameObject.SendMessage("Moveit", hatch_left);
        }
    }
}
