using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : State<Player>{
	AnimatorStateInfo animInfo;
	public override void Enter (Player owner)
	{
		owner.anim.SetBool ("Pick", true);
		animInfo = owner.anim.GetCurrentAnimatorStateInfo(0);
		PickUp ();
	}
	public override void Run (Player owner)
	{
		if(!Input.GetKey(KeyCode.LeftControl)){
			owner.moveControl.ChangeState(new PlayerIdle());
		}
	}
	public override void Exit (Player owner)
	{
		owner.anim.SetBool ("Pick", false);
		Debug.Log ("EndPickUp");
	}
	void PickUp (){
		Debug.Log ("PickUp");
	}
}
