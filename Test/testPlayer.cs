using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : Creature {
	public StateMachine<testPlayer> moveControl;

	public void getDamage(float damage){
		Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
		param.Add ("damage", damage);
		NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
			                               NotifySystem.NotifyType.PLAYER_ON_HURT,
			                               param,
			                               this);
		
		NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
	}
	void Awake(){
		base.Awake ();
		maxHp = 100;
		hp = maxHp;
	}
	// Use this for initialization
	void Start () {
		base.Start ();
		moveControl = new StateMachine<testPlayer> (this);
		moveControl.setCurrentState (new OnGround ());
	}
	
	// Update is called once per frame
	void Update () {
		moveControl.Update();
	}
}
