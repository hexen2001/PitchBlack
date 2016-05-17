using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : BuffList
	{
		public int attackDamage = 5;

		private const float corpseDestroyDelay = 5f;
		public float hp
		{
			get
			{
				return m_hp;
			}
			private set
			{
				m_hp = Mathf.Clamp( value, 0, hpMax );
				UpdateLifeState ();
			}
		}
		[SerializeField]
		private float m_hp = 100;
		public float hpMax = 100;
		public float hpRecoverSpeed = 1f;
		//	黑暗造成的每秒伤害
		public float darkDamage = 1f;
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
		public bool hasLight
		{
			get
			{
				return HasBuff(BuffType.Light)|| powerLight.isLightUp;
			}
		}
		//	生命恢复逻辑
		private void UpdateRecoverHp()
		{
			if (hpRecoverSpeed > 0f&& hasLight)
			{
				hp += (hpRecoverSpeed * Time.deltaTime);
			}
		}
		[SerializeField]
		private bool m_isLife = true;
		public PowerLight powerLight = null;
		public MarineBeHit beHit;

		void UpdateLifeState ()
		{
			if (hp <= float.Epsilon)
			{
				Die ();
			}
		}

		public void Damage(int damagePoint)
		{
			if( isLife )
			{
				hp -= damagePoint;
				UpdateLifeState ();
			}
		}
		public void OnHit(Bullet bullet)
		{
			Damage(bullet.damagePoint );
		}
		//	处死角色
		private void Die()
		{
			isLife = false;
			m_hp = 0;
			Destroy( gameObject, corpseDestroyDelay );
		}
		public float power
		{
			get
			{
				if( powerLight == null )
				{
					return 0f;
				}
				return powerLight.power;
			}
			set
			{
				if( powerLight == null )
				{
					return;
				}
				powerLight.power = value;
			}
		}
		//	是否处于无限能量模式
		//	此状态中可以恢复能量
		public bool isFreePowerMode
		{
			get
			{
				return HasBuff (BuffType.RecoverPowerSpeed);
			}
		}
		//	被伤害逻辑
		//	这个伤害来自黑暗中的怪物
		//	一种逻辑上的直接伤害
		void UpdateDarkDamage()
		{
			if (isLife && !hasLight)
			{
				hp -= darkDamage * Time.deltaTime;
			}
		}
		//	回复能量逻辑
		void UpdateRecoverPower()
		{
			if (isLife && isFreePowerMode)
			{
				powerLight.isFreePowerMode = isFreePowerMode;
			}
		}
		protected virtual void Update()
		{
			UpdateRecoverPower();

			UpdateDarkDamage();

			UpdateRecoverHp();
		}
	}
}