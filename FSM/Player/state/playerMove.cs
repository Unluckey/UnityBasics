using UnityEngine;
using System.Collections;

public class playerMove : State<Player>{
	override public void Enter(Player owner){
		//owner.anim.SetBool ();
	}
	override public void Run(Player owner){
		KeyCheck (owner);
	}
	override public void Exit(Player owner){
		//owner.anim.SetBool ();
	}

	void KeyCheck(Player owner){
		float moveVelocity = 0;
		//move
		if (Input.GetKey(KeyCode.LeftArrow)) {
			if(owner.isFacingRight){
				owner.isFacingRight = false;
				owner.spriteRenderer.flipX = true;
			}
			moveVelocity -= owner.speed;
		}else if(Input.GetKey(KeyCode.RightArrow)){
			if(!owner.isFacingRight){
				owner.isFacingRight = true;
				owner.spriteRenderer.flipX = false;
			}
			moveVelocity += owner.speed;
		}
		owner.body.velocity = new Vector2 (moveVelocity + owner.extraVelocity.x, owner.body.velocity.y);

		//Jump
		if (Input.GetKeyDown (KeyCode.Z)&&owner.isOnGround()) {
			owner.moveControl.ChangeState (new PlayerJump ());
		}
	}
}

