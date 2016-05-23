using UnityEngine;
using System.Collections;
namespace Demo4
{
	/// <summary>
	/// 炮塔
	/// </summary>
	public class Turret : Character
	{
		#region 层与阵营关系
		public override Layer selfLayer
		{
			get
			{
				return Layer.Force1;
			}
		}
		public override Layer fireLayer
		{
			get
			{
				return Layer.Force1Fire;
			}
		}
		#endregion


		private Quaternion origionRotation;


		protected override void Awake()
		{
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