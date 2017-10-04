using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

	public float speed = 3f;
	private GameObject player; 
	private Rigidbody rb;
	public Transform target; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody> ();
		if (target == null) {
			target = player.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		rb.velocity = Vector3.Normalize( target.position - transform.position) * speed ;
		Debug.DrawRay (transform.position, transform.forward*2);
	}
}
