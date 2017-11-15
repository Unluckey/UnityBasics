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
		}
	}
}
