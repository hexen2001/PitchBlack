using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Monster : Character
	{
		public Transform target;
		public NavMeshAgent nav;
		public Gun gun;
		public float fireRange = 4f;
		public int fireLayer
		{
			get{
				return (int)Layer.Force2Fire;
			}
		}
		protected override void Update()
		{
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
			Quaternion rotation = Quaternion.LookRotation (
              (target.position - transform.position).normalized, transform.up
         	 );
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation,0.2f );

			//	update fire
			if (gun != null)
			{
				if (!gun.IsCooldown)
				{
					var go = gun.Fire ();
					go.layer = fireLayer;
				}
			}
		}
	}
}