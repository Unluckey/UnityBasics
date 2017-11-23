using UnityEngine;
using System.Collections;

public class PlayerJump : State<Player>{
	
	public override void Enter (Player owner)
	{
		Debug.Log ("enterJump");
		//owner.anim.SetBool ();
	}
	public override void Run (Player owner)
	{
	}
	public override void Exit (Player owner)
	{
		
	}
}

