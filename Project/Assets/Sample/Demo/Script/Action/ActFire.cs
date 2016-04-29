// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class ActTurretBase : FsmStateAction
	{
		private Turret m_turret;
		protected Turret turret
		{
			get
			{
				if (null == m_turret)
				{
					m_turret = Fsm.GameObject.GetComponent<Turret> ();
				}
				return m_turret;
			}
		}
	}
	[ActionCategory("Pitch Black")]
	public class ActFire : ActTurretBase
	{
		public override void OnUpdate()
		{
			if (turret.gun.IsCooldown)
			{
				turret.Fire ();
			}
		}
	}
}