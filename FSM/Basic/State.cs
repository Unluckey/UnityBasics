using UnityEngine;
using System.Collections;

public class State<EntityType>
{
	public virtual void Enter(EntityType owner){
		
	}

	public virtual void Run (EntityType owner){

	}

	public virtual void Exit(EntityType owner){
	
	}
	/*public virtual bool OnMessage(EntityType owner,Telegram telegram){
		return false;
	}*/
}

