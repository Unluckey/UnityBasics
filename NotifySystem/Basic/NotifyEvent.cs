using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotifySystem{
	
	public class NotifyEvent {
		//how to use???;
		protected Dictionary<string, System.Object> arguments;

		public Dictionary<string, System.Object> Params
		{
			get { return arguments; }
			set { arguments = value; }
		}

		protected NotifyType type;
		protected Object sender;

		public NotifyType Type{
			get{return type;}
			set{ type = value; }
		}
		public Object Sender;

		public NotifyEvent(NotifyType type, Object sender)
		{
			Type = type;
			Sender = sender;
			if (arguments == null)
			{
				arguments = new Dictionary<string, System.Object>();
			}
		}

		public NotifyEvent(NotifyType type, Dictionary<string, System.Object> args, Object sender = null)
		{
			Type = type;
			arguments = args;
			Sender = sender;
			if (arguments == null)
			{
				arguments = new Dictionary<string, System.Object>();
			}
		}

	}

}