using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HpText : NotifySystem.MonoListener {
	NotifySystem.Listener listener = null;
	public Creature target = null;

	void Awake(){
		Dictionary<NotifySystem.NotifyType,NotifySystem.EventListenerDelegate> recieverDic =
			new Dictionary<NotifySystem.NotifyType, NotifySystem.EventListenerDelegate> ();
		NotifySystem.EventListenerDelegate reciever = new NotifySystem.EventListenerDelegate (UpdateUI);
		recieverDic.Add (NotifySystem.NotifyType.CREATURE_CHANGE_HP,reciever);
		recieverDic.Add (NotifySystem.NotifyType.CREATURE_CHANGE_MAXHP,reciever);

		listener = new NotifySystem.Listener (recieverDic);
	}
	void Start(){
		UpdateUI (null);
	}

	void UpdateUI(NotifySystem.NotifyEvent notifyEvent){
		if (target) {
			GetComponent<Text> ().text = (target.hp.ToString () + "/" + target.maxHp.ToString ());
		}
	}
}
