using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public Camera cam;
	public float cameraRotateSpeed;
	public float distanceToGround;
	public float jumpSpeed;
	public float moveSpeed;
	public float mouseX;
	public float mouseY;
	public float mouseXSensitivity;
	public float mouseYSensitivity;
	public float scrollwheel;

	// Use this for initialization
	void Start () {
		cameraRotateSpeed = 1000.0f;
		distanceToGround = this.GetComponentInChildren<CapsuleCollider>().bounds.extents.y;
		jumpSpeed = 70.0f;
		moveSpeed = 5.0f;
		mouseX = 0.0f;
		mouseY = 0.0f;
		mouseXSensitivity = 8.0f;
		mouseYSensitivity = 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			Vector3 forward = cam.transform.forward;
			forward.y = 0;
			this.transform.position += forward.normalized * Time.deltaTime * moveSpeed;
		} else if (Input.GetKey(KeyCode.S)) {
			Vector3 forward = cam.transform.forward;
			forward.y = 0;
			this.transform.position -= forward.normalized * Time.deltaTime * moveSpeed;
		}
		
		if (Input.GetKey(KeyCode.A)) {
			Vector3 right = cam.transform.right;
			right.y = 0;
			this.transform.position -= right.normalized * Time.deltaTime * moveSpeed;
		} else if (Input.GetKey(KeyCode.D)) {
			Vector3 right = cam.transform.right;
			right.y = 0;
			this.transform.position += right.normalized * Time.deltaTime * moveSpeed;
		}
				
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (IsGrounded()) {
				Vector3 up = cam.transform.up;
				up.x = 0;
				up.z = 0;
				this.transform.position += up.normalized * Time.fixedDeltaTime * jumpSpeed;
			}
		}
		
		if (Input.GetMouseButton(0)) {
			mouseX += Input.GetAxis("Mouse X") * mouseXSensitivity;
			mouseY -= Input.GetAxis("Mouse Y") * mouseYSensitivity;
			this.GetComponentInChildren<SphereCollider>().transform.localEulerAngles = new Vector3(mouseY, mouseX, 0);
		}
		
		if (Input.GetMouseButton(1)) {
			this.transform.RotateAround(this.transform.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * cameraRotateSpeed);
		}
		
		scrollwheel = Input.GetAxis("Mouse ScrollWheel");
		if (scrollwheel != 0) {
			cam.transform.position += cam.transform.forward.normalized * scrollwheel * 10.0f;
		}
	}
	
	bool IsGrounded() {
		return Physics.Raycast(this.transform.position, -Vector3.up, distanceToGround + 0.1f);
	}
}