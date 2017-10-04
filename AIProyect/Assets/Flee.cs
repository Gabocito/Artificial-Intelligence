using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour {

	public float speed = 3f;
	public float fleeRadius = 5f; 
	private GameObject player; 
	private Rigidbody rb; 
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); 
		rb = GetComponent<Rigidbody> ();
	}

	void GoAway () { 
		Quaternion rot = Quaternion.LookRotation(transform.position - player.transform.position); 
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
		rb.velocity = Vector3.Normalize(transform.position - player.transform.position) * speed ;

	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.forward*2);
		float distance;
		distance = (transform.position - player.transform.position).magnitude; 

		Debug.Log (distance);
		if (distance < fleeRadius) {
			GoAway ();
		} else {
			rb.velocity = new Vector3 (0, 0, 0);
		}
	}
}
