using UnityEngine;
using System.Collections;

namespace Demo2
{
	public enum Camp
	{
		Human,
		Monster,
	}
	public enum Layer
	{
		Force1 = 8,
		Force1Fire = 12,
		Force2 = 9,
		Force2Fire = 13,
	}
	public abstract class Role : MonoBehaviour
	{
		public Weapon weapon;
		public Camp camp = Camp.Human;
		protected virtual void Awake()
		{
			gameObject.layer = selfLayer;
			weapon = GetComponentInChildren<Weapon> ();
		}
		public bool Fire()
		{
			if (weapon != null )
			{
				if( !weapon.isCooldown )
				{
					var bullet = weapon.Fire (this);
					bullet.gameObject.layer = fireLayer;
					return true;
				}
				return false;
			}
			return true;
		}
		public int selfLayer
		{
			get
			{
				switch (camp)
				{
				case Camp.Human:
					return (int)Layer.Force1;
				case Camp.Monster:
				default:
					return (int)Layer.Force2;
				}
			}
		}
		public int fireLayer
		{
			get{
				switch (camp)
				{
				case Camp.Human:
					return (int)Layer.Force1Fire;
				case Camp.Monster:
				default:
					return (int)Layer.Force2Fire;
				}
			}
		}
	}
}