using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffPowerRecover : Buff
	{
		public float recoverSpeed = 0f;
		public override BuffType type
		{
			get
			{
				return BuffType.RecoverPowerSpeed;
			}
		}
		protected void Update()
		{
			self.power += recoverSpeed * Time.deltaTime;
		}		
	}
}