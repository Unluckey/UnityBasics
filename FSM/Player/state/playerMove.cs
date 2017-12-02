using UnityEngine;
using System.Collections;

public class playerMove : State<Player>{
	override public void Enter(Player owner){
		owner.anim.SetBool("move",true);
	}
	override public void Run(Player owner){
		PlayerInputChecker.CheckFall (owner);
		KeyCheck (owner);
	}
	override public void Exit(Player owner){
		owner.anim.SetBool ("move",false);
	}

	void KeyCheck(Player owner){
		PlayerInputChecker.instance.CheckHorizonMove (owner);
		//Jump
		if (Input.GetKey(KeyCode.Z)&&owner.isOnGround()) {
			owner.moveControl.ChangeState (new PlayerJump ());
		}
		if (!(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))) {
			owner.moveControl.ChangeState (new PlayerIdle ());
		}
	}
}

