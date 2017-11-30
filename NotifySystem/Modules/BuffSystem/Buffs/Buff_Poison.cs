using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class Buff_Poison : Buff<Creature> {
	float DPS = 2f;
	float tickTime = 0f;
	public Buff_Poison(float duration = 0){
		ID = 2;
		buffName = "Poison";
		discription = null;
		this.duration = duration;
	}
	public override void OnAttach (Creature owner, BuffBar<Creature> buffBar)
	{
		base.OnAttach (owner, buffBar);
		restDuration = duration;
	}
	public override void Run (Creature owner)
	{
		base.Run (owner);
		Tick (owner);
		UpdateRestDuration ();
	}
	public override void OnCover (Creature owner, Buff<Creature> buff)
	{
		base.OnCover (owner, buff);
		startTime = Time.time;
		layerCount += 1;
		UpdateRestDuration ();
	}
	void Tick(Creature owner){
		tickTime += Time.deltaTime;
		if (tickTime > 1f) {
			tickTime = 0;
			OnTick (owner);
		}
	}
	void OnTick(Creature owner){
		owner.GetHurt (DPS * layerCount);
	}
}
