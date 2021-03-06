﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoidance : MonoBehaviour {

	private Vector3 target; 
	private Rigidbody rb; 

	// Use this for initialization
	void Start () {
//		target = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody> (); 
	}

	public void setTarget(Vector3 point) {
		target = point;
	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = Vector3.Normalize(target - transform.position);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, 20)) {
			if (hit.transform.position != transform.position && hit.transform.position != target) {
				Debug.DrawLine (transform.position, hit.point);
				dir += hit.normal * 10;
			}	
		}

		Vector3 rightR = transform.position;
		Vector3 leftR = transform.position;

		rightR.x -= 1;
		leftR.x += 1;

		if (Physics.Raycast (rightR, transform.forward, out hit, 20)) {
			if (hit.transform.position != transform.position && hit.transform.position != target) {
				Debug.DrawLine (rightR, hit.point, Color.red);
				dir += hit.normal * 10;
			}	
		}

		if (Physics.Raycast (leftR, transform.forward, out hit, 20)) {
			if (hit.transform.position != transform.position && hit.transform.position != target) {
				Debug.DrawLine (leftR, hit.point, Color.blue);
				dir += hit.normal * 10;
			}	
		}


		Quaternion rot = Quaternion.LookRotation (dir);

		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime);
		transform.position += transform.forward * 5 * Time.deltaTime;

	}
}
