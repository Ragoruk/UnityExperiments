using UnityEngine;
using System.Collections;

using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	public override void OnStartClient() {
		OnPlayerConnect();
	}
	
	[Command]
	void CmdOnPlayerConnect(int id)
	{
		GameObject.Find ("ServerLogic").GetComponent<Server>().addPlayer(id);
	}
	
	[ClientCallback]
	void OnPlayerConnect()
	{
		CmdOnPlayerConnect(GetInstanceID());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
