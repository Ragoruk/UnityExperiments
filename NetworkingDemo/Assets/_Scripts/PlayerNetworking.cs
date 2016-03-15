using UnityEngine;
using System.Collections;

using UnityEngine.Networking;

public class PlayerNetworking : NetworkBehaviour {

    [SyncVar]
    private Vector3 syncPos;

    float lerpRate = 15;

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            this.GetComponentInChildren<Camera>().enabled = true;
            this.GetComponent<PlayerController>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isLocalPlayer)
        {
            TransmitPosition();
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, syncPos, Time.deltaTime * lerpRate);
        }
	}

    [Command]
    void CmdProvidePositionToServer(Vector3 pos)
    {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        CmdProvidePositionToServer(this.transform.position);
    }
}
