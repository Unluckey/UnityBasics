﻿using UnityEngine;

using System.Collections;

namespace NotifySystem{
	public enum NotifyType
	{
		CREATURE_CHANGE_MAXHP,
		CREATURE_CHANGE_HP,
		CREATURE_ON_HEAL,
		CREATURE_ON_HURT,

		BUFF_ADD,
		BUFF_REMOVE,
		UI_BUFF_UPDATE
	}
}
