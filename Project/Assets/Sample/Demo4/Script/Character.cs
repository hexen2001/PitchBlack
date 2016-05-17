using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : BuffList
	{
		public int attackDamage = 5;

		private const float corpseDestroyDelay = 5f;
		public int hp
		{
			get
			{
				return m_hp;
			}
			private set
			{
				m_hp = Mathf.Clamp( value, 0, hpMax );
			}
		}
		[SerializeField]
		private int m_hp = 100;
		public int hpMax = 100;
		public float hpRecoverDelay = 2f;
		public float hpRecoverSpeed = 1f;
		private float m_lastDamageTime = 0f;
		private float m_recoverHpValue = 0f;
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
		private void SetDamageTimeByRecoverHpLogic()
		{
			m_recoverHpValue = 0f;
			m_lastDamageTime = Time.time;
		}
		private void UpdateRecoverHp()
		{
			if( m_lastDamageTime + hpRecoverDelay < Time.time )
			{
				m_recoverHpValue += hpRecoverSpeed * Time.deltaTime;
				int recoverHPStep = (int)m_recoverHpValue;
				if( recoverHPStep > 0 )
				{
					hp += recoverHPStep;
					m_recoverHpValue -= recoverHPStep;
				}
			}
		}
		[SerializeField]
		private bool m_isLife = true;
		public PowerLight powerLight = null;
		public MarineBeHit beHit;
		public void Damage(int damagePoint)
		{
			if( isLife )
			{
				hp -= damagePoint;
				if( hp == 0 )
				{
					Die();
				}
				SetDamageTimeByRecoverHpLogic();
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
			hp = 0;
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
		void UpdateBeHitLogic()
		{
			if( beHit.enabled == powerLight.isLightUp )
			{
				beHit.enabled = !powerLight.isLightUp;
			}
		}
		//	回复能量逻辑
		void UpdateRecoverPower()
		{
			powerLight.isFreePowerMode = isFreePowerMode;
		}
		protected virtual void Update()
		{
			UpdateRecoverPower();

			UpdateBeHitLogic();

			if( powerLight.isLightUp )
			{
				UpdateRecoverHp();
			}
		}
	}
}