using UnityEngine;
using System.Collections;

public class NPCMovementController : MonoBehaviour {

	private float timer;
	private CapsuleCollider npc;
	private float moveSpeed;
	private bool isInteracting;

	// Use this for initialization
	void Start () {
		timer = 3.0f;
		npc = GameObject.Find("Simple NPC").GetComponent<CapsuleCollider>();
		moveSpeed = 4.0f;
		isInteracting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (! isInteracting) {
			timer -= Time.deltaTime;
			if (timer <= 0.0f) {
				Vector3 prevAngle = npc.transform.eulerAngles;
				int random = Random.Range(0, 360);
				npc.transform.eulerAngles = new Vector3(prevAngle.x, random, prevAngle.z);
				timer = 3.0f;
			}
			
			Vector3 forward = npc.transform.forward;
			forward.y = 0;
			npc.transform.position += forward.normalized * Time.deltaTime * moveSpeed;
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.name == "Simple NPC") {
			Vector3 prevAngle = collider.transform.eulerAngles;
			collider.transform.eulerAngles = new Vector3(prevAngle.x, prevAngle.y - 180, prevAngle.z);
		}
	}
	
	public void setInteracting(bool interacting) {
		isInteracting = interacting;
	}
}
