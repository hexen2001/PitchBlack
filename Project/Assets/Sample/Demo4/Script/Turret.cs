using UnityEngine;
using System.Collections;
namespace Demo4
{
	public class Turret : Character
	{
		public Vision vision;
		public Gun gun;
		private Quaternion origionRotation;
		void Awake()
		{
			origionRotation = transform.rotation;
		}
		void Fire()
		{
			if (!gun.IsCooldown )
			{
				var go = gun.Fire ();
				go.GetComponent<Bullet> ().damagePoint = attackDamage;
				go.layer = vision.gameObject.layer;
			}
		}

		protected void Update()
		{
			if (vision.target != null)
			{
				Vector3 dir = vision.target.transform.position - transform.position;
				dir.y = 0f;
				dir.Normalize ();
				var rotation = Quaternion.LookRotation (dir, transform.up);
				gun.transform.rotation = Quaternion.Slerp (gun.transform.rotation, rotation, 0.3f);


				Fire ();
			}
			else
			{
				gun.transform.rotation = Quaternion.Slerp (gun.transform.rotation, origionRotation, 0.08f);
			}
		}
	}
}