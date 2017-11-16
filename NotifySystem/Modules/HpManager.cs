using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NotifySystem{
	public class HpManager:Listener
	{
		GameEntityManager entityManager = GameEntityManager.getInstance();

		public HpManager(){
			recieverDic.Add (NotifyType.CREATURE_ON_HURT, new EventListenerDelegate (dealDamage));
			recieverDic.Add(NotifyType.CREATURE_ON_HEAL,new EventListenerDelegate(dealHealing));
			register();
		}

		void dealHealing(NotifyEvent notifyEvent){
			float healValue = (float)notifyEvent.Params ["healValue"];
			Creature sender = notifyEvent.Sender as Creature;
			Debug.Log ("dealHealing get");
			Debug.Log ("NotifyType:" + notifyEvent.Type.ToString ());
			Debug.Log (" SenderID:" + sender.id+" HealValue:"+healValue);

			sender.hp = Mathf.Clamp (sender.hp+healValue,0,sender.maxHp);
		}

		void dealDamage(NotifyEvent notifyEvent){
			float damage = (float)notifyEvent.Params ["damage"];
			Creature sender = notifyEvent.Sender as Creature;
			Debug.Log ("dealDamage get");
			Debug.Log ("NotifyType:" + notifyEvent.Type.ToString ());
			Debug.Log (" SenderID:" + sender.id+" Damage:"+damage);

			sender.hp = Mathf.Clamp (sender.hp-damage,0,sender.maxHp);
		}
	}
}

