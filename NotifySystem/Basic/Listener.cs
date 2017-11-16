using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace NotifySystem{
	[Serializable]
	public class Listener{
		public Dictionary<NotifyType,EventListenerDelegate> recieverDic = null;

		public Listener(){
			recieverDic = new Dictionary<NotifyType, EventListenerDelegate> ();
		}
		public Listener(NotifyType notifyType,EventListenerDelegate eventReceiver){
			recieverDic = new Dictionary<NotifyType, EventListenerDelegate> ();
			recieverDic.Add (notifyType,eventReceiver);
			register ();
		}
			
		public Listener(Dictionary<NotifyType,EventListenerDelegate> recieverDic){
			this.recieverDic = recieverDic;
			register ();
		}

		public void register(){
			foreach (var Key in recieverDic.Keys) {
				NotificationCenter.getInstance ().registerObserver (Key, recieverDic[Key]);
			}
		}
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