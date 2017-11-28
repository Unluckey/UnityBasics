using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Fragile : Buff<Creature> {
	float extraRate = 0.5f;
	public Buff_Fragile(float duration = 0){
		ID = 1;
		buffName = "Fragile";
		discription = null;
		recieverDic.Add (BuffCallback.VALUE_APPLY_DAMAGE, new BuffDelegator (ProcessValue));

		this.duration = duration;
	}
	float ProcessValue(System.Object owner, float value){
		return value * extraRate;
	}

	public override void OnAttach (Creature owner,BuffBar<Creature> buffBar)
	{
		base.OnAttach (owner,buffBar);

	}
	public override void Run (Creature owner)
	{
		base.Run (owner);
		Debug.Log ("FragileRuning in "+owner.GetID().ToString());
	}
	public override void OnCover (Creature owner,Buff<Creature> buff)
	{
		startTime = Time.time;
		duration = buff.duration;
		base.OnCover (owner,buff);
	}
}
