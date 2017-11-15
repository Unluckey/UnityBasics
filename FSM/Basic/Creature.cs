using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Creature:BaseEntity
{
	public float hp;
	public float maxHp;

	public float speed;
	public float maxSpeed;

	public bool onGround;

	public Vector2 extraVelocity;

	public void GetHurt(float damage){
		Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
		param.Add ("damage", damage);
		NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
			                               NotifySystem.NotifyType.CREATURE_ON_HURT,
			                               param,
			                               this);
		NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
	}

	public void GetHealing(float healValue){
		Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
		param.Add ("healValue", healValue);
		NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
			NotifySystem.NotifyType.CREATURE_ON_HEAL,
			param,
			this);
		NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
	}

}

