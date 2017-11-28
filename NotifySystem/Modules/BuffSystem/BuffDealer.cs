using UnityEngine;
using System;


class BuffDealer:NotifySystem.Listener{
	GameEntityManager entityManager = GameEntityManager.getInstance();
	public BuffDealer(){
		recieverDic.Add (
			NotifySystem.NotifyType.BUFF_ADD,
			new NotifySystem.EventListenerDelegate (AttachBuff)
		);

			//???
		recieverDic.Add (
			NotifySystem.NotifyType.BUFF_REMOVE,
			new NotifySystem.EventListenerDelegate (RemoveBuff)
		);
		register ();
	}

	void AttachBuff (NotifySystem.NotifyEvent notifyEvent)
	{
		(notifyEvent.Params ["target"] as Creature).buffs.AttachBuff (
			notifyEvent.Params ["buff"] as Buff<Creature>
		);
		Debug.Log ("Buff!!!");
	}


	void RemoveBuff(NotifySystem.NotifyEvent notifyEvent){
	}

}
