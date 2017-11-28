using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NotifySystem{
	public class ModuleManager : MonoBehaviour
	{
		List<Listener> listeners = new List<Listener>();

		void Awake(){
			listeners.Add(new HpManager());
			listeners.Add (new BuffDealer ());
		}

		void OnDisable(){
			foreach(Listener listener in listeners){
				NotificationCenter.getInstance ().removeObserver (listener);
			}
		}

	}
}
