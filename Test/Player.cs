using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature {

	public bool isFacingRight = true;
	public StateMachine<Player> moveControl;

	public Transform groundCheckPoint;
	public float groundCheckRadius = 0.1f;

	public Rigidbody2D body;
	public SpriteRenderer spriteRenderer;
	void Awake(){
		base.Awake ();
	}
	// Use this for initialization
	void Start () {
		base.Start ();
		groundCheckPoint = transform.Find ("GroundCheckPoint").transform;
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
		moveControl.Update();
	}
	void fixedUpdate(){
		
	}
	public bool isOnGround(){
		Collider2D[] Colliders = Physics2D.OverlapCircleAll (groundCheckPoint.position, groundCheckRadius);
		foreach (Collider2D col in Colliders) {
			if (col.tag.Equals ("ground")) {
				onGround = true;
			}
		}
		return onGround;
	}
}
