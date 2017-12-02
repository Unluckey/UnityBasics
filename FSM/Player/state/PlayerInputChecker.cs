using UnityEngine;
using System.Collections;

public class PlayerInputChecker
{
	private PlayerInputChecker(){
	}
	private static PlayerInputChecker Instance = null;
	public static PlayerInputChecker instance{
		get{
			if (Instance == null) {
				Instance = new PlayerInputChecker ();
			}
			return Instance;
		}
		set{ }
	}
	public static  void CheckFall(Player owner){
		if (!owner.isOnGround() && owner.body.velocity.y < 0 ){
			owner.moveControl.ChangeState (new PlayerFall ());
		}
	}
	public void CheckHorizonMove(Player owner){
		float moveVelocity = 0;
		//move
		if (Input.GetKey(KeyCode.LeftArrow)) {
			owner.faceLeft ();
			moveVelocity -= owner.speed;
		}else if(Input.GetKey(KeyCode.RightArrow)){
			owner.faceRight ();
			moveVelocity += owner.speed;
		}
		owner.body.velocity = new Vector2 (moveVelocity + owner.extraVelocity.x, owner.body.velocity.y);
	}
	public void CheckHorizonMoveByForce(Player owner){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			owner.faceLeft ();
			owner.body.AddForce (new Vector2 (-owner.jumpMoveForce, 0));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			owner.faceRight ();
			owner.body.AddForce (new Vector2 (owner.jumpMoveForce, 0));
		}
	}
}

