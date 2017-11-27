using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWander : MonoBehaviour {

	public float maxSpeed = 3f;
	private Rigidbody rb;
	private float time = 0.0f;
	public float interpolationPeriod = 2f;
	public List<Node> path;
	private Node current;
	private Grid grid;
	private Node target;
	private GameObject player;
	private GameObject platform;
	private WallAvoidance avoid;

	// Use this for initialization
	void Start () {
		platform = GameObject.FindGameObjectWithTag ("Platform");
		grid = platform.GetComponent<Grid> ();
		avoid = GetComponent<WallAvoidance> ();
		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("entre");
		rb.velocity = maxSpeed * (transform.forward);
		time += Time.deltaTime;
		Debug.Log (time);
		if (time >= interpolationPeriod) {
			current = grid.NodeFromWorldPoint (transform.position);
			List<Node> neighbours = grid.GetNeighbors (current);
			List<Vector3> points = new List<Vector3> ();
			int nextNode = Random.Range (0, neighbours.Count);
			while (!neighbours [nextNode].walkable) {
				nextNode = Random.Range (0, neighbours.Count);
			}
			transform.LookAt(neighbours[nextNode].position); 
			rb.velocity = maxSpeed * (transform.forward);
			time = time - interpolationPeriod;
		}
		Debug.Log ("sali");
	}

	void OnDrawGizmos() {
		if (path != null) {
			Gizmos.color = Color.green;
			Gizmos.DrawLine (transform.position, path[0].position);
		}

	}
}