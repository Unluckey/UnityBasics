using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace NotifySystem{
	[Serializable]
	public class Listener{
		public bool isSingle = false;
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

		public void register( ){
			foreach (var Key in recieverDic.Keys) {
				NotificationCenter.getInstance ().registerObserver (Key, recieverDic[Key],isSingle);
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
	public class MonoListener:MonoBehaviour{
		Listener listener = null;
		public bool isSingle{
			get{
				if (listener == null)
					listener = new Listener ();
				return listener.isSingle;
			}
			set{
				if (listener == null)
					listener = new Listener ();
				listener.isSingle = value;
			}
		}
		public Dictionary<NotifyType,EventListenerDelegate> recieverDic{
			get{
				if (listener == null)
					listener = new Listener ();
				return listener.recieverDic;
			}
			set{
				if (listener == null)
					listener = new Listener ();
				listener.recieverDic = value;
			}
		}
		public void register(){
			listener.register ();
		}
		public void register(Dictionary<NotifyType,EventListenerDelegate> recieverDic){
			listener.register (recieverDic);
		}

		public void register(NotifyType notifyType,EventListenerDelegate eventReceiver){
			listener.register (notifyType, eventReceiver);
		}
	}
}