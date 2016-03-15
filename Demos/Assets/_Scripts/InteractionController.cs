using UnityEngine;
using System.Collections;

public class InteractionController : MonoBehaviour {

	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "Player") {
			
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.name == "Player") {
			
		}
	}
}