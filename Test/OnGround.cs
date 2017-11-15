using UnityEngine;
using System.Collections;

public class OnGround : State<testPlayer>
{
	Rigidbody2D body;
	override public void Execute(testPlayer owner){
		body = owner.GetComponent<Rigidbody2D> ();
		float spdY = owner.GetComponent<Rigidbody2D> ().velocity.y;
		float spdX = owner.GetComponent<Rigidbody2D> ().velocity.x;
		if (Input.GetKeyDown (KeyCode.UpArrow)&&owner.onGround) {
			Debug.Log ("jump!");
			spdY = 3.5f;
			owner.onGround = false;
		} else if (Input.GetKeyUp (KeyCode.UpArrow)&&owner.GetComponent<Rigidbody2D> ().velocity.y > 0) {
			spdY = spdY/10;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			spdX = -2;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			spdX = 2;
			body.AddForce(new Vector2(2,0));
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			spdX = 0;
		}
		body.velocity = new Vector2 (spdX, spdY);
	}
}

