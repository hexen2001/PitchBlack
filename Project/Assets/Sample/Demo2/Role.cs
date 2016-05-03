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

		public float bodySize = 1f;


		private static Vector3 deathTweenMotionDistance = new Vector3 (0,1,0);
		private const float deathShowTime = 1.5f;

		public Camp camp = Camp.Human;

		public int hp = 100;
		public int maxHP = 100;

		protected Vision vision;
		protected Weapon weapon;
		public Role target
		{
			get
			{
				if (null == m_target)
				{
					if (vision != null)
					{
						if( vision.first != null )
						{
							m_target = vision.first.GetComponent <Role> ();
						}
					}
				}
				return m_target;
			}
		}
		[SerializeField]
		private Role m_target = null;
		protected virtual void Awake()
		{
			gameObject.layer = selfLayer;
			weapon = GetComponentInChildren<Weapon> ();
			vision = GetComponentInChildren<Vision> ();
		}
		public void OnHit(Bullet bullet)
		{
			Damage (bullet.damagePoint);
		}
		[ContextMenu("Test Damage")]
		public void TestDamage()
		{
			Damage (20);
		}
		public void Damage(int point)
		{
			hp = Mathf.Clamp( hp - point, 0, maxHP );
			if (hp == 0)
			{
				OnDead();
			}
		}
		protected virtual void OnDead()
		{
			enabled = false;
			iTween.MoveAdd (gameObject, deathTweenMotionDistance, deathShowTime);
			Object.Destroy (gameObject, deathShowTime);
		}
		[ContextMenu("Fire")]
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

		void OnDrawGizmos()
		{
			Gizmos.color = new Color(0,0,1,0.25f);
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawWireSphere( Vector3.zero, bodySize / 2f );
		}
	}
}