using UnityEngine;
using System.Collections;

public class PlayerJump : State<Player>{
	
	public override void Enter (Player owner)
	{
		Debug.Log ("enterJump");
		owner.anim.SetBool ("jump",true);
		owner.anim.SetBool ("onGround", false);
		owner.body.velocity = new Vector2(owner.body.velocity.x,owner.jumpVelocity);
	}
	public override void Run (Player owner){
		KeyCheck (owner);
		PlayerInputChecker.CheckFall(owner);
	}
	public override void Exit (Player owner)
	{
		owner.anim.SetBool ("jump",false);
	}
	void KeyCheck(Player owner){
		PlayerInputChecker.instance.CheckHorizonMove (owner);
	/*	if (Input.GetKeyUp (KeyCode.Z)) {
			owner.body.velocity = new Vector2 (owner.body.velocity.x, 0);
		}*/
	}
}

