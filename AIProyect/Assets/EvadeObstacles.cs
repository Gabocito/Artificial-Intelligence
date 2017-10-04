using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeObstacles : MonoBehaviour {

	private Seek seek; 
	private Rigidbody rb;
	private GameObject player; 
	private float time;
	public float resumeSearchTime = 2f; 
	// Use this for initialization

	[Header("Sensors")]
	public float sensorLength = 2f;
	public float rayAngle = 30f;
	public float forceMagnitude = 1f;
	private Vector3 rayPosition; 
	private bool avoiding = false;

	private void Sensors() {  
		RaycastHit hit;
		if (avoiding == true) return; 
		//Center Ray
		//Right Angle Ray
		Vector3 rightRayDir = Quaternion.AngleAxis(rayAngle, transform.up)*transform.forward;
		Vector3 leftRayDir = Quaternion.AngleAxis(-rayAngle, transform.up)*transform.forward;
		Vector3 dir = transform.forward;

		if (Physics.Raycast (rayPosition, rightRayDir, out hit, maxDistance: sensorLength)) {
			Debug.Log ("Choque Derecha");
			Debug.DrawLine (rayPosition, hit.point, Color.red);
			if (hit.collider.CompareTag ("Obstacle")) {
				avoiding = true;
				seek.enabled = false;
				transform.LookAt (hit.transform.right);
				//Quaternion rot = Quaternion.LookRotation (hit.transform.right);
				//transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
				rb.velocity = hit.transform.right * seek.speed;
			} 


		}

		//Left Angle Ray
		else if (Physics.Raycast (rayPosition, leftRayDir, out hit, maxDistance: sensorLength)) {

			Debug.Log ("Choque Izquierda");
			Debug.DrawLine(rayPosition, hit.point, Color.green);

			if (hit.collider.CompareTag ("Obstacle")) {
				avoiding = true;
				seek.enabled = false;
				transform.LookAt (-hit.transform.right);
				//Quaternion rot = Quaternion.LookRotation (-hit.transform.right);
				//transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
				rb.velocity = -hit.transform.right * seek.speed;
			}
		}
			

	}

	void FixedUpdate() {
		rayPosition = transform.position;
		rayPosition.z += 0.5f;
		//rayPosition.y += 0.5f;
		Debug.DrawRay (transform.position, transform.forward*2);
		Sensors();
	}


		
	void Start () {
		seek = GetComponent<Seek>();
		seek.enabled = true;
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= resumeSearchTime && avoiding==true ) {
			time = 0;
			avoiding = false;
			seek.enabled = true;
		}
	}
}
