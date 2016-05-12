using UnityEngine;
using System.Collections;
using Demo2;

namespace Demo4
{
	public class RecoverPowerField : BuffField
	{
		public float powerRecoverSpeed = 1f;
		protected override void OnCharacterIn(Character target)
		{
			var obj = target.gameObject.GetOrAddComponent<BuffPowerRecover> ();
			obj.recoverSpeed += powerRecoverSpeed;
			obj.AddRef ();
		}
		protected override void OnCharacterOut(Character target)
		{
			var obj = target.gameObject.GetOrAddComponent<BuffPowerRecover> ();
			if (obj!=null)
			{
				obj.recoverSpeed += powerRecoverSpeed;
				obj.Release ();
			}
		}
	}
}