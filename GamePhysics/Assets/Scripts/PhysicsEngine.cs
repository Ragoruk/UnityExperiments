using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class PhysicsEngine : MonoBehaviour {

	public float mass;				// [kg]
	public Vector3 velocityVector;	// average velocity of this FixedUpdate() [m s^-1]
	public Vector3 netForceVector;	// N [g m s^-2]
	private List<Vector3> forceVectorList = new List<Vector3>();
	private PhysicsEngine[] physicsEngineArray;
	
	private const float bigG = 6.673e-11f;	// N m kg^-1)^2 [m^3 s^-2 kg^-1] 
	
	// Use this for initialization
	void Start() {
		SetupThrustTrails();
		physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
	}
		
	void FixedUpdate () {
		RenderTrails();
		CalculateGravity();
		UpdatePosition();
	}
	
	public void AddForce(Vector3 forceVector) {
		forceVectorList.Add (forceVector);
	}
	
	void CalculateGravity() {
		foreach (PhysicsEngine physicsEngineA in physicsEngineArray) {
			foreach (PhysicsEngine physicsEngineB in physicsEngineArray) {
				if (physicsEngineA != physicsEngineB) {
					Debug.Log ( "Calculating gravitational force exerted on " + physicsEngineA.name +
							" due to the gravity of " + physicsEngineB.name);
					Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
					float rSquared = Mathf.Pow (offset.magnitude, 2f);
					float gravityMagnitude = bigG * physicsEngineA.mass * physicsEngineB.mass / rSquared;
					Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;
					physicsEngineA.AddForce(-gravityFeltVector);
				}
			}
		}
	}
	
	void UpdatePosition() {
		// sum the forces and clear the list
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector = netForceVector + forceVector;
		}
		forceVectorList = new List<Vector3>();	// clear the list

		// calculate position change due to net force
		Vector3 accelerationVector = netForceVector / mass;
		velocityVector += accelerationVector * Time.deltaTime;
		transform.position += velocityVector * Time.deltaTime;
	}
	
	/*
		code used for drawing thrust trails
	*/
	private LineRenderer lineRenderer;
	private int numberOfForces;
	public bool showTrails = true;
	
	void SetupThrustTrails () {		
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	
	void RenderTrails() {
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}
}
