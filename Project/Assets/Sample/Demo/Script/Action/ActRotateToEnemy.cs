// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActAtEnemy : ActTurretBase
	{
		public override void OnUpdate()
		{
			var tf = turret.transform;
			var enemy = turret.vision.first;
			if (null == enemy)
			{
				return;
			}
			var forward = enemy.transform.position - tf.position;
			var rot = Quaternion.LookRotation (forward, tf.up);
			turret.transform.rotation = Quaternion.Lerp( turret.transform.rotation, rot, 0.1f );
		}
	}
}