using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
using System.Collections.Generic;
public class CustomNetworkManager : NetworkManager {

	GameObject prefab;
	Dictionary<string, GameObject> players;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void OnClientConnect (NetworkConnection conn) {
		base.OnClientConnect(conn);
		
	}
}
