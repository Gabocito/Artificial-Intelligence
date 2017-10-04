using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSeek : MonoBehaviour {

	public float maxAcceleration = 3f;
	private GameObject player; 
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce ( Vector3.Normalize( player.transform.position - transform.position) * maxAcceleration );
	}
}
