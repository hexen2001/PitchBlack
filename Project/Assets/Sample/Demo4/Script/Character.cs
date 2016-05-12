using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : MonoBehaviour
	{
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
		public bool isFreePowerMode
		{
			get
			{
				return GetComponent<BuffPowerRecover>()!=null;
			}
		}
		void UpdateBeHitLogic()
		{
			if( beHit.enabled == powerLight.isLightUp )
			{
				beHit.enabled = !powerLight.isLightUp;
			}
		}
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