using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Demo3;

namespace Demo4
{
	public class Marine : Character
	{
		public NavMeshAgent nav;
		public float speed = 6;
		public float accSpeed = 10f;
		private float m_speed = 0f;
		protected override void Update()
		{
			base.Update ();
			Vector3 dir;
			if( InputUtil.GetWorldInputDir( out dir ) )
			{
				nav.Move( dir * m_speed * Time.deltaTime );
				m_speed = Mathf.Clamp( m_speed + accSpeed * Time.deltaTime, 0f, speed );

				transform.rotation = Quaternion.Slerp(
					transform.rotation,
					Quaternion.LookRotation( dir, transform.up ),
					0.1f ); ;
			}
			else
			{
				m_speed = Mathf.Clamp( m_speed - accSpeed * Time.deltaTime, 0f, speed );
			}

			UpdateDarkDamage ();
			UpdateRecoverPower();
		}
		public int damage = 1;
		//	被伤害逻辑
		//	这个伤害来自黑暗中的怪物
		//	一种逻辑上的直接伤害
		void UpdateDarkDamage()
		{
			if (isLife && !hasLight)
			{
				hp -= damage * Time.deltaTime;
			}
		}
		public override bool hasLight
		{
			get{
				return powerLight.isLightUp || base.hasLight;
			}
		}



		public PowerLight powerLight = null;
		/// <summary>
		/// 电量
		/// </summary>
		/// <value>The power.</value>
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
		/// <summary>
		/// 回复能量逻辑
		/// </summary>
		void UpdateRecoverPower()
		{
			if (isLife && isFreePowerMode)
			{
				powerLight.isFreePowerMode = isFreePowerMode;
			}
		}


	}
}