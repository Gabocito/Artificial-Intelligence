using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

	public float maxSpeed = 3f;
	private float maxRotation = 180f;
	private Rigidbody rb;
	private float time = 0.0f;
	private float interpolationPeriod = 1f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= interpolationPeriod) {
			transform.rotation = Quaternion.AngleAxis (Random.Range (-1f, 1f) * maxRotation, transform.up);
			rb.velocity = maxSpeed * (transform.forward);
			time = time - interpolationPeriod;
		}
	}
}
