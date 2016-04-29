// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActRotateToParentForward : ActTurretBase
	{
		public override void OnUpdate()
		{
			if (turret.transform.parent == null)
			{
				return;
			}
			turret.transform.rotation = Quaternion.Lerp
				(turret.transform.rotation, turret.transform.parent.rotation, 0.1f);
		}
	}
}