using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalk : MonoBehaviour {

	private Rigidbody rb;
	private float time = 0.0f;
	public float interpolationPeriod = 2f;
	public List<Node> path;
	private Node current;
	private Grid grid;
	private Node target;
	private GameObject player;
	private GameObject platform;

	// Use this for initialization
	void Start () {
		platform = GameObject.FindGameObjectWithTag ("Platform");
		grid = platform.GetComponent<Grid> ();
		rb = GetComponent<Rigidbody> (); 
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		rb.velocity = new Vector3 (0, 0, 0);
		if (time >= interpolationPeriod) {
			current = grid.NodeFromWorldPoint (transform.position);
			List<Node> neighbours = grid.GetNeighbors (current);
			List<Vector3> points = new List<Vector3> ();
			int nextNode = Random.Range (0, neighbours.Count);
			while (!neighbours [nextNode].walkable) {
				nextNode = Random.Range (0, neighbours.Count);
			}
			transform.LookAt(neighbours[nextNode].position); 
			time = time - interpolationPeriod;
		}
	}

	void OnDrawGizmos() {
		if (path != null) {
			Gizmos.color = Color.green;
			Gizmos.DrawLine (transform.position, path[0].position);
		}

	}
}
