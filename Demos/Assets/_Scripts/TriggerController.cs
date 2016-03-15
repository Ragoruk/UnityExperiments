using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	public Collider player;
	public GameObject tooltip;
	bool isInteractable;

	// Use this for initialization
	void Start () {
		isInteractable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isInteractable && Input.GetKeyDown(KeyCode.F)) {			
			TextMesh text = tooltip.GetComponent<TextMesh>();
			if (text.text == "Hi") {
				text.text = "Hello";
			} else if (text.text == "Hello") {
				text.text = "How can I help you?";
			} else {
				text.text = "Hi";
			}
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider == player) {
			tooltip.GetComponent<MeshRenderer>().enabled = true;
			isInteractable = true;
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider == player) {
			tooltip.GetComponent<MeshRenderer>().enabled = false;
			isInteractable = false;
			tooltip.GetComponent<TextMesh>().text = "F to interact";
		}
	}
}
