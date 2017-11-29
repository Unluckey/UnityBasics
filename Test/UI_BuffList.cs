using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UI_BuffList : NotifySystem.MonoListener
{
	public Creature target;
	Text buffText;

	void Awake(){
		recieverDic.Add(NotifySystem.NotifyType.UI_BUFF_UPDATE,new NotifySystem.EventListenerDelegate(UpdateUI));
		register ();
		buffText = transform.Find ("Text").GetComponent<Text> ();
	}
	void UpdateUI(NotifySystem.NotifyEvent evt){
		Creature owner = (evt.Params ["owner"] as Creature);
		if (owner.GetID () == target.GetID ()) {
			string listString = "Buff:\n";
			foreach (Buff<Creature> buff in owner.buffs.buffList) {
				listString = listString + buff.GetName (); 
			}

			Debug.Log ("BuffUI Update " + owner.GetID ().ToString ());
			buffText.text = listString;
		}
	}
}

