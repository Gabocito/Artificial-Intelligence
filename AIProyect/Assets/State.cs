using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State {

	void enterState ();

	void exitState ();

	List<Transition> getTransitions ();

}

public class SeekState : State {

	private Seek seek;
	public List<Transition> transitions; 

	public SeekState(Seek s) {
		seek = s;
		transitions = new List<Transition> ();
	}

	public void enterState () {
		Debug.Log ("Entre Seek state");
		seek.enabled = true;
	}

	public void exitState () {
		seek.enabled = false;
	}

	public void addTransition (Transition t) {
		transitions.Add (t);
	}

	public List<Transition> getTransitions () {
		return transitions;
	}
}

public class WanderState : State {

	private PathWander wander;
	public List<Transition> transitions; 

	public WanderState(PathWander w) {
		wander = w;
		transitions = new List<Transition> ();
	}

	public void enterState () {
		Debug.Log ("Entre Wander state");
		wander.enabled = true;
	}

	public void exitState () {
		wander.enabled = false;
	}

	public void addTransition (Transition t) {
		transitions.Add (t);
	}

	public List<Transition> getTransitions () {
		return transitions;
	}
}

public class StalkState : State {

	private Stalk stalk;
	public List<Transition> transitions; 

	public StalkState(Stalk s) {
		stalk = s;
		transitions = new List<Transition> ();
	}

	public void enterState () {
		Debug.Log ("Entre Stalkkkk state");
		stalk.enabled = true;
	}

	public void exitState () {
		stalk.enabled = false;
	}

	public void addTransition (Transition t) {
		transitions.Add (t);
	}

	public List<Transition> getTransitions () {
		return transitions;
	}
}