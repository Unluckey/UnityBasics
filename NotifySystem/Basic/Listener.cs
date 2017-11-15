using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace NotifySystem{
	[Serializable]
	public class Listener{

		public void register(Dictionary<NotifyType,EventListenerDelegate> recieverDic){
			foreach (var Key in recieverDic.Keys) {
				NotificationCenter.getInstance ().registerObserver (Key, recieverDic[Key]);
			}
		}

		public void register(NotifyType notifyType,EventListenerDelegate eventReceiver){
			NotificationCenter.getInstance ().registerObserver (notifyType, eventReceiver);
		}
	}
}