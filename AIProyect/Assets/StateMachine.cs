using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public List<State> states;
	private State initialState;
	private State currentState;


	// Use this for initialization
	void Start () {
		currentState = initialState;
	}
	
	// Update is called once per frame
	void Update () {

		Transition triggeredTransition = null;

		foreach (Transition t in currentState.getTransitions()) {
			if (t.isTriggered ()) {
				triggeredTransition = t;
				break;
			}
		}

		if (triggeredTransition) {
			State targetState = triggeredTransition.getTargetState ();

			// actions = currentState.getExitAction ();
			// actions += triggeredTransition.getAction ();
			// actions += targetState.getAction ();

			currentState = targetState;
		}


	}
}
