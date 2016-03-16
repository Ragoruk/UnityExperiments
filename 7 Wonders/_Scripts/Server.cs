using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
using System.Collections.Generic;

public class Server : NetworkBehaviour {

	LinkedList<Empire> empires;
	bool gameStarted;
	int numPlayers;

	public override void OnStartServer () {
		empires = new LinkedList<Empire>();
		gameStarted = false;
		numPlayers = 0;
		Debug.Log ("server started");
	}
	
	public void addPlayer(int id) {
		numPlayers++;
		Debug.Log ("Player " + numPlayers + " " + id);
		
		
		empires.AddLast(new Empire(id));
	}
/*	
	public int[] getLeftResources(int id) {
		
	}
*/
}
