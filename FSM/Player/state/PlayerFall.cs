using UnityEngine;
using System.Collections;

public class PlayerFall : State<Player>{
	public override void Enter (Player owner)
	{
		base.Enter (owner);
		owner.anim.SetBool ("fall",true);
	}
	public override void Run(Player owner){
		KeyCheck (owner);
		if (owner.isOnGround ()) {
			owner.anim.SetBool ("onGround",true);
			owner.moveControl.ChangeState (new PlayerIdle ());
		}
	}
	public override void Exit (Player owner)
	{
		base.Exit (owner);
		owner.anim.SetBool ("fall", false);
	}

	void KeyCheck(Player owner){
		PlayerInputChecker.instance.CheckHorizonMove (owner);
	}
}

