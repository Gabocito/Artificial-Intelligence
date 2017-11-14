using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public Vector2 gridWorldSize;
	public float offSet;
	Node[] grid;

	void Awake() {
		CreateGrid();
	}

	void CreateGrid() {
		grid = new Node[114];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		List<Vector2[]> triangles = GetTriangles ();
		int i = 0;
		int[] notWalkable = new int[24] { 4, 5, 6, 7, 9, 22, 24, 25, 27, 28, 29, 59, 60, 65, 66, 67, 70, 97, 79, 80, 101, 102, 103, 104 };

		foreach (Vector2[] t in triangles) {
			float x = (t[0][0] + t[1][0] + t[2][0]) / 3;
			float y = (t[0][1] + t[1][1] + t[2][1]) / 3;
			bool walkable = true;
			for (int j = 0; j < notWalkable.Length; j++) {
				if (i == notWalkable [j]) {
					walkable = false;
					break;
				}
			}
			grid[i] = new Node(walkable, worldBottomLeft + Vector3.right * ( x * offSet) + Vector3.forward * ( y * offSet), t[0], t[1], t[2]);
			i++;
		}
	}

	List<Vector2[]> GetTriangles() {
		List<Vector2[]> triangles = new List<Vector2[]>();

		triangles.Add(new Vector2[3] { new Vector2 (0, 0), new Vector2 (1, 0), new Vector2 (1, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 0), new Vector2 (0, 2), new Vector2 (1, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 0), new Vector2 (2, 0), new Vector2 (1, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 0), new Vector2 (1, 2), new Vector2 (2, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 0), new Vector2 (2, 2), new Vector2 (3, 1) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 0), new Vector2 (3, 1), new Vector2 (4, 0) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 1), new Vector2 (2, 2), new Vector2 (3, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 1), new Vector2 (4, 1), new Vector2 (3, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 2), new Vector2 (4, 1), new Vector2 (4, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 0), new Vector2 (3, 1), new Vector2 (4, 1) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 2), new Vector2 (1, 2), new Vector2 (0, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 2), new Vector2 (0, 3), new Vector2 (1, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 2), new Vector2 (2, 2), new Vector2 (1, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 3), new Vector2 (2, 2), new Vector2 (2, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 3), new Vector2 (2, 3), new Vector2 (1, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 3), new Vector2 (1, 4), new Vector2 (0, 5) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 3), new Vector2 (1, 4), new Vector2 (2, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 3), new Vector2 (2, 4), new Vector2 (3, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 3), new Vector2 (3, 4), new Vector2 (3, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 2), new Vector2 (2, 3), new Vector2 (3, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 3), new Vector2 (3, 4), new Vector2 (4, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 2), new Vector2 (4, 2), new Vector2 (4, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 4), new Vector2 (4, 4), new Vector2 (3, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 4), new Vector2 (3, 6), new Vector2 (4, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 4), new Vector2 (2, 5), new Vector2 (3, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 4), new Vector2 (2, 5), new Vector2 (3, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 4), new Vector2 (0, 5), new Vector2 (2, 5) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 5), new Vector2 (3, 6), new Vector2 (2, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 6), new Vector2 (2, 8), new Vector2 (4, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 8), new Vector2 (4, 7), new Vector2 (4, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 5), new Vector2 (2, 5), new Vector2 (0, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 6), new Vector2 (2, 5), new Vector2 (2, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 6), new Vector2 (2, 6), new Vector2 (2, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 8), new Vector2 (1, 7), new Vector2 (2, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 6), new Vector2 (1, 7), new Vector2 (0, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 8), new Vector2 (1, 8), new Vector2 (0, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (0, 10), new Vector2 (1, 8), new Vector2 (1, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 9), new Vector2 (1, 10), new Vector2 (2, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (1, 8), new Vector2 (2, 8), new Vector2 (1, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 8), new Vector2 (2, 10), new Vector2 (1, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 8), new Vector2 (2, 10), new Vector2 (3, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 8), new Vector2 (3, 9), new Vector2 (3, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (2, 10), new Vector2 (3, 10), new Vector2 (3, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 8), new Vector2 (3, 10), new Vector2 (4, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (3, 8), new Vector2 (4, 8), new Vector2 (4, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 0), new Vector2 (4, 3), new Vector2 (5, 0) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 3), new Vector2 (5, 0), new Vector2 (5, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 3), new Vector2 (4, 4), new Vector2 (5, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 4), new Vector2 (4, 5), new Vector2 (5, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 4), new Vector2 (4, 5), new Vector2 (5, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 6), new Vector2 (5, 6), new Vector2 (5, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 5), new Vector2 (4, 6), new Vector2 (5, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 6), new Vector2 (4, 10), new Vector2 (5, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (4, 10), new Vector2 (5, 7), new Vector2 (5, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 0), new Vector2 (5, 2), new Vector2 (6, 1) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 0), new Vector2 (7, 0), new Vector2 (7, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 1), new Vector2 (5, 2), new Vector2 (7, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 2), new Vector2 (5, 3), new Vector2 (6, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 3), new Vector2 (6, 2), new Vector2 (6, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 2), new Vector2 (6, 4), new Vector2 (7, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 2), new Vector2 (7, 2), new Vector2 (7, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 3), new Vector2 (6, 3), new Vector2 (5, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 4), new Vector2 (6, 3), new Vector2 (6, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 4), new Vector2 (6, 4), new Vector2 (6, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 4), new Vector2 (5, 7), new Vector2 (6, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 4), new Vector2 (7, 5), new Vector2 (6, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 6), new Vector2 (7, 5), new Vector2 (7, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 6), new Vector2 (6, 8), new Vector2 (7, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 6), new Vector2 (5, 7), new Vector2 (6, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 7), new Vector2 (5, 8), new Vector2 (6, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 8), new Vector2 (7, 7), new Vector2 (7, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 8), new Vector2 (6, 9), new Vector2 (7, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 8), new Vector2 (5, 10), new Vector2 (6, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (5, 10), new Vector2 (6, 9), new Vector2 (6, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 9), new Vector2 (6, 10), new Vector2 (7, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 9), new Vector2 (7, 8), new Vector2 (7, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 10), new Vector2 (8, 9), new Vector2 (10, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 9), new Vector2 (10, 9), new Vector2 (10, 10) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 9), new Vector2 (7, 10), new Vector2 (8, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 9), new Vector2 (8, 9), new Vector2 (8, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 7), new Vector2 (7, 9), new Vector2 (8, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 7), new Vector2 (8, 9), new Vector2 (9, 9) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 7), new Vector2 (9, 9), new Vector2 (9, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 7), new Vector2 (9, 9), new Vector2 (10, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 9), new Vector2 (10, 9), new Vector2 (10, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 7), new Vector2 (10, 7), new Vector2 (10, 8) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 7), new Vector2 (9, 6), new Vector2 (9, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 6), new Vector2 (9, 7), new Vector2 (10, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 6), new Vector2 (10, 6), new Vector2 (10, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 5), new Vector2 (9, 6), new Vector2 (10, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 6), new Vector2 (7, 7), new Vector2 (8, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 6), new Vector2 (8, 6), new Vector2 (8, 7) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 6), new Vector2 (8, 7), new Vector2 (9, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 6), new Vector2 (8, 5), new Vector2 (9, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 5), new Vector2 (7, 6), new Vector2 (8, 5) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 5), new Vector2 (9, 5), new Vector2 (9, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 5), new Vector2 (8, 4), new Vector2 (9, 5) });
		triangles.Add(new Vector2[3] { new Vector2 (6, 4), new Vector2 (7, 5), new Vector2 (8, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 4), new Vector2 (9, 4), new Vector2 (9, 5) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 4), new Vector2 (9, 5), new Vector2 (10, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 5), new Vector2 (10, 4), new Vector2 (10, 6) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 3), new Vector2 (7, 4), new Vector2 (8, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 3), new Vector2 (8, 3), new Vector2 (8, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 3), new Vector2 (8, 4), new Vector2 (9, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 3), new Vector2 (9, 3), new Vector2 (9, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 3), new Vector2 (9, 4), new Vector2 (10, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 3), new Vector2 (10, 3), new Vector2 (10, 4) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 3), new Vector2 (10, 3), new Vector2 (10, 0) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 3), new Vector2 (8, 2), new Vector2 (9, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 0), new Vector2 (7, 3), new Vector2 (8, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (7, 0), new Vector2 (8, 2), new Vector2 (9, 0) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 0), new Vector2 (8, 2), new Vector2 (9, 2) });
		triangles.Add(new Vector2[3] { new Vector2 (9, 0), new Vector2 (10, 0), new Vector2 (9, 3) });
		triangles.Add(new Vector2[3] { new Vector2 (8, 2), new Vector2 (9, 2), new Vector2 (9, 3) });

		return triangles;
	}

	float Sign (Vector2 p1, Vector2 p2, Vector2 p3) {
		return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
	}

	bool PointInTriangle (Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3) {
		bool b1, b2, b3;

		b1 = Sign(pt, v1, v2) < 0.0f;
		b2 = Sign(pt, v2, v3) < 0.0f;
		b3 = Sign(pt, v3, v1) < 0.0f;

		return ((b1 == b2) && (b2 == b3));
	}

	public Node NodeFromWorldPoint(Vector3 worldPosition) {
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

		for (int i = 0; i < grid.Length; i++) {
			Vector3 A = worldBottomLeft + Vector3.right * (grid [i].vertices [0] [0] * offSet) + Vector3.forward * (grid [i].vertices [0] [1] * offSet);
			Vector3 B = worldBottomLeft + Vector3.right * (grid [i].vertices [1] [0] * offSet) + Vector3.forward * (grid [i].vertices [1] [1] * offSet);
			Vector3 C = worldBottomLeft + Vector3.right * (grid [i].vertices [2] [0] * offSet) + Vector3.forward * (grid [i].vertices [2] [1] * offSet);
			Vector2 v1 = new Vector2 (A [0], A [2]);
			Vector2 v2 = new Vector2 (B [0], B [2]);
			Vector2 v3 = new Vector2 (C [0], C [2]);
			Vector2 p = new Vector2 (worldPosition [0], worldPosition [2]);
			if (PointInTriangle (p, v1, v2, v3)) {
				return grid [i];
			}
		}
		return null;
	}

	public List<Node> GetNeighbors(Node n) {
		List<Node> neighbors = new List<Node> ();

		for (int i = 0; i < grid.Length; i++) {
			if (grid[i].position == n.position) {
				continue;
			}

			foreach (Vector2 v in n.vertices) {
				foreach (Vector2 v1 in grid[i].vertices) {
					if (v1 == v) {
						neighbors.Add (grid[i]);
						break;
					}
				}
			}
		}
		return neighbors;
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
		if (grid != null) {
			Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
			for (int i = 0; i < grid.Length; i++) {
				Vector3 A = worldBottomLeft + Vector3.right * (grid [i].vertices [0] [0] * offSet) + Vector3.forward * (grid [i].vertices [0] [1] * offSet);
				Vector3 B = worldBottomLeft + Vector3.right * (grid [i].vertices [1] [0] * offSet) + Vector3.forward * (grid [i].vertices [1] [1] * offSet);
				Vector3 C = worldBottomLeft + Vector3.right * (grid [i].vertices [2] [0] * offSet) + Vector3.forward * (grid [i].vertices [2] [1] * offSet);
				Gizmos.color = (grid[i].walkable)?Color.white:Color.red;
				Gizmos.DrawLine (A, B);
				Gizmos.DrawLine (A, C);
				Gizmos.DrawLine (B, C);
			}
		} 
	}
}
