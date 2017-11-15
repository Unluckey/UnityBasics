using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace message{
public class TelegramCompare : IComparer<Telegram>
	{
		public int Compare(Telegram x, Telegram y)
		{
			if (x == null)
			{
				if (y == null)
					return 0;
				else
					return -1;
			}
			else
			{
				if (y == null)
					return 1;
				else
					return x.delay.CompareTo(y.delay);
			}
		}
	}
}