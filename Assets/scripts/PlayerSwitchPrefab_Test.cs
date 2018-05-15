using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSwitchPrefab_Test : NetworkBehaviour
{
    private GameObject dogPrefab;
    private GameObject humanPrefab;

    // Use this for initialization
    void Start()
    {
        //dogPrefab = gameObject.transform.GetChild(1).gameObject;
        //humanPrefab = gameObject.transform.GetChild(0).gameObject;
        //if (isServer && isLocalPlayer)
        //{
        //    //Server host player is always the human
        //    humanPrefab.SetActive(false);

        //}
        //else if (!isServer && isLocalPlayer)
        //{
        //    //Server client player is always the dog
        //    dogPrefab.SetActive(false);
        //}
        //if (isServer && !isLocalPlayer)
        //{
        //    dogPrefab.SetActive(true);

        //}
        //else if (!isServer && !isLocalPlayer)
        //{
        //   humanPrefab.SetActive(true);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
