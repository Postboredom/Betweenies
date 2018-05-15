using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }


public class NetPlayer : NetworkBehaviour{
    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;

    void Start()
    {
        EnablePlayer();
    }

    void DisablePlayer()
    {
        //turn on anything that's shared
        onToggleShared.Invoke(false);

        if (isLocalPlayer)
        {
            //if we are local player, we start local 
            onToggleLocal.Invoke(false);
        }
        else
        {
            //else we want to boot up other instances
            onToggleRemote.Invoke(false);
        }
    }

    void EnablePlayer()
    {
        //turn on anything that's shared
        onToggleShared.Invoke(true);

        if (isLocalPlayer)
        {
            //if we are local player, we start local 
            onToggleLocal.Invoke(true);
        }
        else
        {
            //else we want to boot up other instances
            onToggleRemote.Invoke(true);
        }
    }

}
