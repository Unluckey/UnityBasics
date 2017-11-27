using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Creature:BaseEntity
{
	BuffBar<Creature> buffs;
	float HP = 0;
	public float hp{
		get{
			return HP;
		}
		set{
			HP = value;
			Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
			NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
				                               NotifySystem.NotifyType.CREATURE_CHANGE_HP,
				                               this);
			NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
		}
	}
	float mHp = 0;
	public float maxHp{
		get{
			return mHp;
		}
		set{
			mHp = value;
			Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
			NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
				NotifySystem.NotifyType.CREATURE_CHANGE_MAXHP,
				this);
			NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
		}
	}
	public bool onGround;
	public Vector2 extraVelocity;

	public Animator anim;

	public virtual void GetHurt(float damage){
		Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
		param.Add ("damage", damage);
		NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
			                               NotifySystem.NotifyType.CREATURE_ON_HURT,
			                               param,
			                               this);
		NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
	}

	public virtual void GetHealing(float healValue){
		Dictionary<string,System.Object> param = new Dictionary<string, System.Object> ();
		param.Add ("healValue", healValue);
		NotifySystem.NotifyEvent evt = new NotifySystem.NotifyEvent (
			NotifySystem.NotifyType.CREATURE_ON_HEAL,
			param,
			this);
		NotifySystem.NotificationCenter.getInstance ().postNotification (evt);
	}
	void Awake(){
		buffs = new BuffBar<Creature>(this);
	}
	void Start(){

	}

	public virtual bool isOnGround(){
		return false;
	}

}
