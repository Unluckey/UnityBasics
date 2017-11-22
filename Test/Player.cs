using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature {
	public bool isFacingRight;
	public StateMachine<Player> moveControl;

	void Awake(){
		base.Awake ();
	}
	// Use this for initialization
	void Start () {
		base.Start ();
		anim = GetComponent<Animator> ();
		moveControl = new StateMachine<Player> (this);
		moveControl.setCurrentState (new PlayerIdle ());
		maxHp = 100.0f;
		hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		moveControl.Update();
	}
}
