using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature {

	public float jumpVelocity;
	public float jumpMoveForce = 1.0f;
	public float speed;
	public float maxSpeed;

	public bool isFacingRight = true;
	public StateMachine<Player> moveControl;

	public Transform groundCheckPoint;
	public float groundCheckRadius = 0.05f;

	public Rigidbody2D body;
	public SpriteRenderer spriteRenderer;
	protected void Awake(){
		base.Awake ();
	}
	// Use this for initialization
	protected void Start () {
		base.Start ();
		groundCheckPoint = transform.Find ("GroundCheckPoint");
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		moveControl = new StateMachine<Player> (this);
		moveControl.setCurrentState (new PlayerIdle ());

		maxHp = 100.0f;
		hp = maxHp;
	}

	// Update is called once per frame
	void Update () {
		base.Update ();
	}
	void FixedUpdate(){
		moveControl.Update();
	}
	public override bool isOnGround(){
		Collider2D[] Colliders = Physics2D.OverlapCircleAll (groundCheckPoint.position, groundCheckRadius);
		onGround = false;
		foreach (Collider2D col in Colliders) {
			if (col.tag.Equals ("ground")) {
				onGround = true;
			}
		}
		return onGround;
	}

	public void faceRight(){
		isFacingRight = true;
		spriteRenderer.flipX = false;
	}
	public void faceLeft(){
		isFacingRight = false;
		spriteRenderer.flipX = true;
	}
}
