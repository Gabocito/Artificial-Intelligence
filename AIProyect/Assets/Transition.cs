using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Transition {
	
	bool isTriggered (Vector3 pos);

	State getNextState ();

	void getAction ();

}

public class WanderTransition : Transition {

	private GameObject player;
	private State nextState;
	private string type;
	private Grid grid;
	private FieldOfView fov;

	public WanderTransition(State s, string t, Grid g, FieldOfView f) {
		nextState = s;
		type = t;
		grid = g;
		fov = f;
	}

	public bool isTriggered (Vector3 pos) {
//		Debug.Log ("wander ->");
//		Debug.Log (type); 
		if (type == "seek") {
			if (fov.visibleTargets.Count > 0)
				return true;
			return false;
		} else if (type == "stalk") {
			Node n = grid.NodeFromWorldPoint (pos);
			if (n.stalkable) {
				return true;
			}
			return false;
		}
		return false;
	}

	public State getNextState () {
		return nextState;
	}

	public void getAction () {
		return;
	}
		
	private float DistanceBetweenPoints (Vector3 p1, Vector3 p2){
		return Mathf.Sqrt( Mathf.Pow (p1.x - p2.x, 2) +
			Mathf.Pow (p1.y - p2.y, 2) +
			Mathf.Pow (p1.z - p2.z, 2));
	}
		
}

public class SeekTransition : Transition {

	private GameObject player;
	private State nextState;
	private string type;
	private FieldOfView fov;

	public SeekTransition(State s, string t, FieldOfView f) {
		nextState = s;
		type = t;
		fov = f;
	}

	public bool isTriggered (Vector3 pos) {
//		Debug.Log ("seek ->");
//		Debug.Log (type);
		if (fov.visibleTargets.Count == 0)
			return true;
		return false;
	}

	public State getNextState () {
		return nextState;
	}

	public void getAction () {
		return;
	}

	private float DistanceBetweenPoints (Vector3 p1, Vector3 p2){
		return Mathf.Sqrt( Mathf.Pow (p1.x - p2.x, 2) +
			Mathf.Pow (p1.y - p2.y, 2) +
			Mathf.Pow (p1.z - p2.z, 2));
	}

}

public class StalkTransition : Transition {

	private GameObject player;
	private State nextState;
	private string type;
	private FieldOfView fov;
	private float time = 0.0f;
	private float stalkDuration = 5f;

	public StalkTransition(State s, string t, FieldOfView f) {
		nextState = s;
		type = t;
		fov = f;
	}

	public bool isTriggered (Vector3 pos) {
//		Debug.Log ("stalk ->");
//		Debug.Log (type);
		time += Time.deltaTime;
		if (type == "seek") {
			if (fov.visibleTargets.Count > 0)
				return true;
			return false;
		} else if (type == "wander") {
			if (time >= stalkDuration) {
				time = 0;
				return true;
			}
			return false;
		}
		return false;
	}

	public State getNextState () {
		return nextState;
	}

	public void getAction () {
		return;
	}

	private float DistanceBetweenPoints (Vector3 p1, Vector3 p2){
		return Mathf.Sqrt( Mathf.Pow (p1.x - p2.x, 2) +
			Mathf.Pow (p1.y - p2.y, 2) +
			Mathf.Pow (p1.z - p2.z, 2));
	}

}

