using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Demo3;

namespace Demo4
{
	public class Marine : Character
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
				return Layer.Force1;
			}
		}
		#endregion

		/// <summary>
		/// 更新逻辑
		/// </summary>
		protected override void Update()
		{
			base.Update();

			if( !isLife )
			{
				return;
			}

			UpdateMotion();
			UpdateDarkDamage();
		}
		protected override void OnData(GameSettings settings)
		{
			base.OnData( settings );
			items.AddItem( ItemType.Power, 100 );
			items.AddItem( ItemType.PowerMax, 100 );
		}


		/// <summary>
		/// 运动逻辑
		/// </summary>
		private void UpdateMotion()
		{
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

		/// <summary>
		/// 造成的伤害
		/// </summary>
		public int darkDamage = 1;

		public float darkDamageIntervals = 1f;
		private float m_nextDarkDamageTime = 0f;

		//	被伤害逻辑
		//	这个伤害来自黑暗中的怪物
		//	一种逻辑上的直接伤害
		void UpdateDarkDamage()
		{
			if (isLife && !hasLight)
			{
				if( Time.time >= m_nextDarkDamageTime )
				{
					hp -= darkDamage;
					m_nextDarkDamageTime = Time.time + darkDamageIntervals;
				}
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
		public int power
		{
			get
			{
				return items.Get( ItemType.Power );
			}
			set
			{
				items.Set( ItemType.Power, Mathf.Clamp( value, 0, items.Get( ItemType.PowerMax ) ) );
			}
		}



	}
}