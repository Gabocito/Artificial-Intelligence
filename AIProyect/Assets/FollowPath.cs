using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {
	
	public float speed = 0.5f;
	private Rigidbody rb;
	private float distance;
	public Vector3 target;
	private int i = 0;
	private WallAvoidance avoid;

	private float DistanceBetweenPoints (Vector3 p1, Vector3 p2){
		return Mathf.Sqrt( Mathf.Pow (p1.x - p2.x, 2) +
			Mathf.Pow (p1.y - p2.y, 2) +
			Mathf.Pow (p1.z - p2.z, 2));
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 
		avoid = GetComponent<WallAvoidance> ();
	}

	public void Follow (List<Vector3> path) {
		if (i == 0) {
			target = path [i];
		}
		distance = DistanceBetweenPoints (target, transform.position); 
		if (distance <= 1f) {
			if (i >= path.Count) {
				rb.velocity = new Vector3 (0, 0, 0);
				avoid.enabled = false;
			} else {
				i += 1;
				Debug.Log ("i = " + i);
				target = path [i];
			} 
		} else {
//			rb.velocity = Vector3.Normalize (target - transform.position) * speed;
			avoid.setTarget(target);
			avoid.enabled = true;
			Debug.DrawRay (transform.position, transform.forward * 2);
		}

//		for (int i = 0; i < path.Count; i++) {
//			Quaternion rotation = Quaternion.LookRotation (path [i] - transform.position);
//			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime);
//			transform.position = Vector3.MoveTowards (transform.position, path [i], Time.deltaTime * speed);
//			Debug.DrawRay (transform.position, transform.forward * 2);
//		}
//		Debug.Log ("TERMINE");
	}
}
