using UnityEngine;
using System.Collections;
namespace Demo4
{
	public class Turret : Character
	{
		private Quaternion origionRotation;
		protected override void Awake()
		{
			selfLayer = (int)Layer.Force1;
			fireLayer = (int)Layer.Force1Fire;
			base.Awake ();
			origionRotation = transform.rotation;
		}
		protected override void Update()
		{
			base.Update ();

			if (!isLife)
			{
				return;
			}

			if (vision.target != null)
			{
				var dir = MathUtil.DirAt2D (transform.position, vision.target.transform.position);
				var rotation = Quaternion.LookRotation (dir, transform.up);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.3f);

				if ( Vector3.Dot (dir, transform.forward)>0.8f)
				{
					Fire ();
				}
			}
			else
			{
				mainWeapon.transform.rotation = Quaternion.Slerp
					(mainWeapon.transform.rotation, origionRotation, 0.08f);
			}
		}
		protected override void OnData(GameSettings settings)
		{
			if (mainWeapon != null)
			{
				mainWeapon.damagePoint = settings.turretMainWeaponDamage;
			}
		}
	}
}