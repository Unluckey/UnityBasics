using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightFollower : MonoBehaviour {
	public float followSpeed = 0.1f;

	public Transform player;
	private Vector2 relativePos;
	private float distanceToPlyaer;
	private Vector2 newPos;

	void Awake(){
		relativePos = transform.position - player.position;
		distanceToPlyaer = relativePos.magnitude - 0.5f;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
