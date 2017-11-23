using UnityEngine;
using System.Collections;

public class playerMove : State<Player>{
	override public void Enter(Player owner){
		//owner.anim.SetBool ();
	}
	override public void Run(Player owner){

	}
	override public void Exit(Player owner){
//		owner.anim.SetBool ();
	}
	void KeyCheck(Player owner){
		if (GetKey(KeyCode.LeftArrow)) {
			if(owner.isFacingRight){
			//	owner.SpriteRenderer.flip
			}
		}else if(GetKey(KeyCode.RightArrow)){
			if(!owner.isFacingRight){
			//	flip;
			}
		}
	}
}
