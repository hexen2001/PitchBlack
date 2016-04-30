// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActAtParentForward : ActionBase<Turret>
	{
		public float speed = 0.05f;
		public override void OnLogic()
		{
			if (self.transform.parent == null)
			{
				return;
			}
			self.transform.rotation = Quaternion.Lerp
				(self.transform.rotation, self.transform.parent.rotation, speed);
		}
	}
}