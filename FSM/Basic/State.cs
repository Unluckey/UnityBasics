using UnityEngine;
using System.Collections;

public class State<EntityType>
{
	public virtual void Enter(EntityType owner){
		
	}

	public virtual void Execute (EntityType owner){

	}

	public virtual void Exit(EntityType owner){
	
	}
	/*public virtual bool OnMessage(EntityType owner,Telegram telegram){
		return false;
	}*/
}

