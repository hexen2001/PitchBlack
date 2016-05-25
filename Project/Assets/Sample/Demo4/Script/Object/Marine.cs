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
			UpdateBuff();
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="settings">Settings.</param>
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

		//	被伤害逻辑
		//	这个伤害来自黑暗中的怪物
		//	一种逻辑上的直接伤害
		void UpdateBuff()
		{

			if (darkDamage.activeSelf == hasLight)
			{
				darkDamage.SetActive (!hasLight);
				recoverLife.SetActive (hasLight);
			}


			if (recoverLife.activeSelf != hasLight)
			{
				recoverLife.SetActive (hasLight);
			}


			powerLight.SetActive (isPower);

			powerLightConsume.SetActive (isPowerConsume);
		}
		private bool isPowerConsume
		{
			get{
				return powerLight.activeSelf && items.Get (ItemType.FullPower) == 0;
			}
		}

		public bool isPower
		{
			get{
				return items.Get (ItemType.Power) > 0;
			}
		}
		public GameObject darkDamage;
		public GameObject recoverLife;

		/// <summary>
		/// 灯
		/// </summary>
		public GameObject powerLight = null;
		public GameObject powerLightConsume = null;

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