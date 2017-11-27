using UnityEngine;

using System.Collections;

namespace NotifySystem{
	public enum NotifyType
	{
		CREATURE_CHANGE_MAXHP,
		CREATURE_CHANGE_HP,
		CREATURE_ON_HEAL,
		CREATURE_ON_HURT,

		BUFF_ON_ADD,
		BUFF_ON_REMOVE,
		BLOCK_PLACE
	}
}
