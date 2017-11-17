using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace NotifySystem{
	public delegate void EventListenerDelegate(NotifyEvent notifyEvent);

	public class NotificationCenter{
		private static NotificationCenter instance = null;
		private NotificationCenter() { }
		public static NotificationCenter getInstance()
		{
			if (instance == null)
			{
				instance = new NotificationCenter();
			}
			return instance;
		}

		Dictionary<NotifyType,EventListenerDelegate> notifications = new Dictionary<NotifyType,EventListenerDelegate>();

		public void registerObserver(NotifyType type, EventListenerDelegate listener, bool isSigle = false){
			if (listener == null){
				Debug.LogError("registerObserver: listener不能为空");
				return;
			}
			Debug.Log("NotifacitionCenter: 添加监视" + type);
			EventListenerDelegate tryListener = null;

			if (notifications.TryGetValue (type, out tryListener) && isSigle) {
				foreach (EventListenerDelegate dlg in tryListener.GetInvocationList ()) {
					if (dlg.Method.Name.Equals (listener.Method.Name)) {
						return;
					}
				}
			}
			tryListener += listener;
			notifications[type] = tryListener;
		}
			
		public void removeObserver(NotifyType type, EventListenerDelegate listener){
			if (listener == null){
				Debug.LogError("removeObserver: listener不能为空");
				return;
			}
			Debug.Log("NotifacitionCenter: 移除监视" + type);
			notifications[type] -= listener;
		}

		public void removeAllObservers(){
			notifications.Clear();
		}

		public void postNotification(NotifyEvent notifyEvent){
			EventListenerDelegate listenerDelegate;
			if (notifications.TryGetValue (notifyEvent.Type, out listenerDelegate)) {
				listenerDelegate.Invoke (notifyEvent);
			}
		}

	}
}
