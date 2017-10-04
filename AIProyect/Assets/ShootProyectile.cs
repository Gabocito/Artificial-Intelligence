using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProyectile : MonoBehaviour {

	GameObject prefab;
	private float time;
	public float fireTime = 1f;   
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("Proyectile") as GameObject;	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= fireTime) { 
			if (Input.GetKey (KeyCode.X)) {
				GameObject proyectile = Instantiate (prefab) as GameObject; 
				Rigidbody rb = proyectile.GetComponent<Rigidbody> (); 
				proyectile.transform.position = transform.position + transform.forward * 2;
				rb.velocity = transform.forward * 5f;
				time = 0f; 
			}
		}
	}
}
