﻿// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActFire : ActionBase<Turret>
	{
		public override void OnLogic()
		{
			if (self.gun.IsCooldown)
			{
				self.Fire ();
			}
		}
	}
}