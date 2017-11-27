using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APathFinding: MonoBehaviour {


	private FollowPath follow;
	public List<Node> path;
	private Node current;
	private Grid grid;
	private Node target;
	private GameObject player;
	private GameObject platform;
	private WallAvoidance avoid;
	private Rigidbody rb;

	void search(Node startNode, Node targetNode) {
		
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				RetracePath(startNode,targetNode);
				return;
			}

			foreach (Node neighbour in grid.GetNeighbors(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

	void RetracePath(Node startNode, Node endNode) {
		List<Node> res = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode) {
			res.Add(currentNode);
			currentNode = currentNode.parent;
		}
		res.Reverse();
		path = res;
	}

	private float distanceBetweenPoints (Vector3 p1, Vector3 p2){
		return Mathf.Sqrt( Mathf.Pow (p1.x - p2.x, 2) +
			Mathf.Pow (p1.y - p2.y, 2) +
			Mathf.Pow (p1.z - p2.z, 2));
	}

	int GetDistance(Node nodeA, Node nodeB) {
		return Mathf.FloorToInt(distanceBetweenPoints (nodeA.position, nodeB.position));
	}
		

	void Start() {
		platform = GameObject.FindGameObjectWithTag ("Platform");
		grid = platform.GetComponent<Grid> ();
		follow = GetComponent<FollowPath>();
		player = GameObject.FindGameObjectWithTag("Player");
		avoid = GetComponent<WallAvoidance> ();
		rb = GetComponent<Rigidbody> (); 
	}

	void Update() {
		current = grid.NodeFromWorldPoint (transform.position);
		target = grid.NodeFromWorldPoint (player.transform.position);
		if (!current.position.Equals (target.position)) {
			search (current, target);
			if (!current.position.Equals (target.position)) {
				List<Vector3> points = new List<Vector3> ();
				foreach (Node n in path) {
					points.Add (n.position);
				}
				follow.Follow (points);
			}
		} else {
			rb.velocity = new Vector3 (0, 0, 0);
			avoid.enabled = false;
		}
	}

	void OnDrawGizmos() {
		if (path != null) {
			for (int i = 0; i < path.Count-1; i++) {
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine (path[i].position, path[i+1].position);
			}
		}

	}

}