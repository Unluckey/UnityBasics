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

		public void register(){
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
		Listener lsn = null;
		Listener listener{
			get{
				if (lsn == null)
					lsn =  new Listener ();
				return lsn;
			}
			set{
				lsn = value;
			}
		}

		public bool isSingle{
			get{
				return listener.isSingle;
			}
			set{
				listener.isSingle = value;
			}
		}
		public Dictionary<NotifyType,EventListenerDelegate> recieverDic{
			get{
				return listener.recieverDic;
			}
			set{
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

		void Awake(){
		}
		void Start(){
		}
		void Update(){
		}
		protected void OnDisable(){
			NotificationCenter.getInstance ().removeObserver (listener);
		}
	}
}