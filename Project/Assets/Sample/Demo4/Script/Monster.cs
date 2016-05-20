using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Monster : Character
	{
		protected override void Awake()
		{
			fireLayer = (int)Layer.Force2Fire;
			selfLayer = (int)Layer.Force2;
			base.Awake ();
		}
		public GameObject target
		{
			get{
				if (vision != null)
				{
					return vision.target;
				}
				return null;
			}
		}
		public float fireRange = 4f;
		protected override void Update()
		{
			base.Update ();


			if (!isLife)
			{
				return;
			}

			
			//	check target is exist.
			if (target == null)
			{
				return;
			}

			//	update motion dest
			if ((transform.position - target.transform.position).magnitude > fireRange)
			{
				nav.destination = target.transform.position;
				return;
			}

			//	update rotation
			Quaternion rotation = Quaternion.LookRotation
			(
					(target.transform.position - transform.position).normalized, transform.up
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