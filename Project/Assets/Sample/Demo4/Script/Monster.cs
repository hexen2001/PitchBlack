using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Monster : Character
	{
		public override int selfLayer
		{
			get
			{
				return (int)Layer.Force2;
			}
		}
		public override int fireLayer
		{
			get
			{
				return (int)Layer.Force2Fire;
			}
		}
		public Transform target;
		public float fireRange = 4f;
		protected override void Update()
		{
			base.Update ();
			
			//	check target is exist.
			if (target == null)
			{
				return;
			}

			//	update motion dest
			if ((transform.position - target.position).magnitude > fireRange)
			{
				nav.destination = target.position;
				return;
			}

			//	update rotation
			Quaternion rotation = Quaternion.LookRotation
			(
              (target.position - transform.position).normalized, transform.up
         	);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation,0.2f );

			//	update fire
			Fire();
		}
		protected override void OnData(GameSettings settings)
		{
			hpMax = settings.monsterMaxHP;
		}
	}
}