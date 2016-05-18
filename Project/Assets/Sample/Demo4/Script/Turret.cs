using UnityEngine;
using System.Collections;
namespace Demo4
{
	public class Turret : Character
	{
		public override int selfLayer
		{
			get
			{
				return (int)Layer.Force1;
			}
		}
		public override int fireLayer
		{
			get
			{
				return (int)Layer.Force1Fire;
			}
		}
		private Quaternion origionRotation;
		protected override void Awake()
		{
			base.Awake ();
			origionRotation = transform.rotation;
		}

		protected override void Update()
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