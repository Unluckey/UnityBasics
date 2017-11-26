using UnityEngine;
using System.Collections;

class PlayerIdle:State<Player>{
	override public void Enter(Player owner){
	}
	override public void Run(Player owner){
		Debug.Log("idle");
		KeyCheck(owner);
	}
	override public void Exit(Player owner){
	
	}


	void KeyCheck(Player owner){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			owner.faceLeft ();
			owner.moveControl.ChangeState (new playerMove ());
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			owner.faceRight ();
			owner.moveControl.ChangeState (new playerMove ());
		}
		if (Input.GetKey (KeyCode.Z)&&owner.isOnGround()) {
			owner.moveControl.ChangeState (new PlayerJump ());
		}
	}
}
