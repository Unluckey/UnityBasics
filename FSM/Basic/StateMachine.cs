using UnityEngine;
using System.Collections;


public class StateMachine<T>
{
	T owner;
	State<T> currentState = null;
	State<T> previousState = null;
	State<T> globalState = null;


	public StateMachine(T iniOwner){
		owner = iniOwner;
	}
	public void setCurrentState(State<T> state){
		currentState = state;
		state.Enter (owner);
	}
	// Use this for initialization
	void Start ()
	{
		
	}

	public void Update ()
	{
		if (globalState != null) {
			globalState.Run (owner);
		}
		if (currentState != null) {
			currentState.Run (owner);
		}
	}

	public void ChangeState(State<T> newState){
		previousState = currentState;
		currentState.Exit (owner);
		currentState = newState;
		currentState.Enter (owner);
	}

	public void RevertToPreviousState(){
		ChangeState (previousState);
	}

/*	public bool HandleMessage(Telegram telegram){
		if (currentState != null && currentState.OnMessage (owner,telegram)) {
			return true;
		} else if (globalState != null && globalState.OnMessage (owner,telegram)) {
			return true;
		} else{
			return false;
		}
	}*/


}