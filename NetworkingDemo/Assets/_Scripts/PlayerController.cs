using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float moveSpeed = 5.0f;
    float mouseX = 0.0f;
    float mouseXSensitivity = 8.0f;
    float mouseY = 0.0f;
    float mouseYSensitivity = 8.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey("w"))
        {
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            this.transform.position -= this.transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            this.transform.position += this.transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X") * mouseXSensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * mouseYSensitivity;
            this.transform.localEulerAngles = new Vector3(mouseY, mouseX, 0);
        }
    }
}
