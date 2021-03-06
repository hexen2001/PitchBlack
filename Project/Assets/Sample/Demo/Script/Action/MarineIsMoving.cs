﻿// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class MarineIsMoving : ActionBase<Marine>
	{
		public bool isMoving = true;
		public FsmEvent onEqual;
		public override void OnLogic()
		{
			if (self.isMoving == isMoving )
			{
				Fsm.Event (onEqual);
			}
		}
	}
}