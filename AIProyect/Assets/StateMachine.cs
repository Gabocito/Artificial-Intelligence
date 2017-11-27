using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public List<State> states;
	private State currentState;
	private Seek seek;
	private PathWander wander;
	private Stalk stalk;
	private FieldOfView fov;
	private GameObject plane;
	private Grid grid;

	// Use this for initialization
	void Start () {
		seek = GetComponent<Seek> ();
		wander = GetComponent<PathWander> ();
		stalk = GetComponent<Stalk> ();
		fov = GetComponent<FieldOfView> ();
		plane = GameObject.FindGameObjectWithTag("Platform");
		grid = plane.GetComponent<Grid> ();

		SeekState seekState = new SeekState (seek);
		WanderState wanderState = new WanderState (wander);
		StalkState stalkState = new StalkState (stalk);

		Transition seekT = new SeekTransition (wanderState, "wander", fov);
		Transition wanderT1 = new WanderTransition (seekState, "seek", grid, fov);
		Transition wanderT2 = new WanderTransition (stalkState, "stalk", grid, fov);
		Transition stalkT1 = new StalkTransition (seekState, "seek", fov);
//		Transition stalkT2 = new StalkTransition (wanderState, "wander", fov);

		seekState.addTransition (seekT);
		wanderState.addTransition (wanderT1);
		wanderState.addTransition (wanderT2);
		stalkState.addTransition (stalkT1);
//		stalkState.addTransition (stalkT2);

		currentState = seekState;
		currentState.enterState ();
	}
	
	// Update is called once per frame
	void Update () {

		Transition triggeredTransition = null;

		foreach (Transition t in currentState.getTransitions()) {
			if (t.isTriggered (transform.position)) {
				triggeredTransition = t;
				break;
			}
		}

		if (triggeredTransition != null) {
			State targetState = triggeredTransition.getNextState ();

			currentState.exitState ();
			targetState.enterState ();

			currentState = targetState;
		}


	}
}
