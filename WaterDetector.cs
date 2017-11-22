using UnityEngine;
using System.Collections;

public class WaterDetector : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D hit){
		Debug.Log ("trigger!");
		if (hit.gameObject.GetComponent("Rigidbody2D") != null) {
			Debug.Log ("hel");
			transform.parent.GetComponent<WaterEffect> ().Splash (hit.transform.position.x, hit.gameObject.GetComponent<Rigidbody2D> ().velocity.y/20f);
			//hit.gameObject.GetComponent<testPlayer> ().onGround = true;
			hit.gameObject.GetComponent<Rigidbody2D> ().velocity *= 0.9f;
		}
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.GetComponent<Rigidbody2D> () != null) {
			Rigidbody2D hitBody = hit.gameObject.GetComponent<Rigidbody2D> ();
			float topY = transform.parent.gameObject.GetComponent<WaterEffect> ().startTop;
		    float flowY = Mathf.Max(hit.transform.position.y - topY,0);
			hitBody.velocity = new Vector2(hitBody.velocity.x/2,hitBody.velocity.y);
			hitBody.AddForce (new Vector2 (0,Mathf.Max(10f*(hitBody.mass),0)));	
		}
	}
}