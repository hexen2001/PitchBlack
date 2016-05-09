// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActAtEnemy : ActionBase<Turret>
	{
		public override void OnLogic()
		{
			var tf = self.transform;
			var enemy = self.target;
			if (null == enemy)
			{
				return;
			}
			var forward = enemy.transform.position - tf.position;
			var rot = Quaternion.LookRotation (forward, tf.up);
			self.transform.rotation = Quaternion.Lerp( self.transform.rotation, rot, 0.1f );
		}
	}
}