using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : BuffList
	{
		/// <summary>
		/// 单次攻击造成的伤害
		/// </summary>
		public int attackDamage = 5;
		/// <summary>
		/// 毁尸延迟
		/// </summary>
		private const float corpseDestroyDelay = 5f;
		/// <summary>
		/// 当前生命值
		/// </summary>
		/// <value>The hp.</value>
		public float hp
		{
			get
			{
				return m_hp;
			}
			set
			{
				m_hp = Mathf.Clamp( value, 0, hpMax );
				UpdateLifeState ();
			}
		}
		[SerializeField]
		private float m_hp = 100;
		public float hpMax = 100;
		public float hpRecoverSpeed = 1f;
		public bool isLife
		{
			get
			{
				return m_isLife;
			}
			private set
			{
				m_isLife = value;
			}
		}
		[SerializeField]
		private bool m_isLife = true;

		void UpdateLifeState ()
		{
			if (hp <= float.Epsilon)
			{
				Die ();
			}
		}
		public void OnHit(Bullet bullet)
		{
			hp -= bullet.damagePoint;
		}
		public virtual bool hasLight
		{
			get{
				return HasBuff (BuffType.Light);
			}
		}
		//	处死角色
		private void Die()
		{
			isLife = false;
			m_hp = 0;
			Destroy( gameObject, corpseDestroyDelay );
		}
		/// <summary>
		/// 生命恢复逻辑
		/// </summary>
		private void UpdateRecoverHp()
		{
			if (hpRecoverSpeed > 0f&& hasLight)
			{
				hp += (hpRecoverSpeed * Time.deltaTime);
			}
		}

		protected virtual void Update()
		{

			UpdateRecoverHp();
		}
	}
}