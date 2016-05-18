using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Demo3;

namespace Demo4
{
	public class Marine : Character
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
				return (int)Layer.Force1;
			}
		}
		/// <summary>
		///	移动速度
		/// </summary>
		public float moveSpeed = 8;
		/// <summary>
		/// 加速度
		/// </summary>
		public float accSpeed = 10f;
		/// <summary>
		/// 当前移动速度
		/// </summary>
		private float m_moveSpeed = 0f;
		protected override void Update()
		{
			base.Update ();
			Vector3 dir;
			if( InputUtil.GetWorldInputDir( out dir ) && dir != Vector3.zero )
			{
				nav.Move( dir * m_moveSpeed * Time.deltaTime );
				m_moveSpeed = Mathf.Clamp( m_moveSpeed + accSpeed * Time.deltaTime, 0f, moveSpeed );

				transform.rotation = Quaternion.Slerp(
					transform.rotation,
					Quaternion.LookRotation( dir, transform.up ),
					0.1f ); ;
			}
			else
			{
				m_moveSpeed = Mathf.Clamp( m_moveSpeed - accSpeed * Time.deltaTime, 0f, moveSpeed );
			}

			UpdateDarkDamage ();
			UpdateRecoverPower();
			UpdateRecoverHp();
		}
		/// <summary>
		/// 造成的伤害
		/// </summary>
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
		/// <summary>
		/// 是否有光亮
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public override bool hasLight
		{
			get{
				return powerLight.isLightUp || base.hasLight;
			}
		}
		/// <summary>
		/// 灯
		/// </summary>
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
		/// <summary>
		/// 生命值恢复速度,单位:点数/每秒
		/// </summary>
		public float hpRecoverSpeed = 1f;
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


	}
}