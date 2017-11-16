using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : Creature {
	public StateMachine<testPlayer> moveControl;

	void Awake(){
		base.Awake ();
		maxHp = 100.0f;
		hp = maxHp;
	}
	// Use this for initialization
	void Start () {
		base.Start ();
		moveControl = new StateMachine<testPlayer> (this);
		moveControl.setCurrentState (new OnGround ());
	}
	
	// Update is called once per frame
	void Update () {
		moveControl.Update();
	}
}
