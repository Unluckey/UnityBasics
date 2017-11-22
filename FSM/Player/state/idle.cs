using UnityEngine;
using System.Collections;

class PlayerIdle:State<Player>{
	override public void Enter(Player owner){
	}
	override public void Run(Player owner){
	//Keycheck();
	}
	override public void Exit(Player owner){
	
	}


	void KeyCheck(Player owner){
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			owner.isFacingRight = false;
			owner.moveControl.ChangeState (new playerMove ());
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			owner.isFacingRight = true;
			owner.moveControl.ChangeState (new playerMove ());
		}
	}
}
