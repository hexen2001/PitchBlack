using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public abstract class Character : BuffList
	{
		public Title title
		{
			get
			{
				if (null == m_title)
				{
					m_title = GetComponent<Title> ();
				}
				return m_title;
			}
		}
		private Title m_title;

		private void UpdateHPText()
		{
			if (title != null)
			{
				title.text = ((int)hp).ToString() + "/" + ((int)hpMax).ToString();
			}
		}

		public bool useGlobalSettings = true;
		protected virtual void OnData(GameSettings settings)
		{
		}
		public abstract int selfLayer
		{
			get;
		}
		public abstract int fireLayer
		{
			get;
		}
		protected virtual void Awake()
		{
			gameObject.layer = selfLayer;

			if (useGlobalSettings)
			{
				OnData (Manager.main.settings);
			}
			m_hp = hpMax;
		}
		/// <summary>
		/// 开火方法
		/// </summary>
		public Bullet Fire()
		{
			if (mainWeapon != null && !mainWeapon.IsCooldownTime)
			{
				var bu = mainWeapon.Fire ();
				if (bu != null)
				{
					bu.gameObject.layer = fireLayer;
					return bu;
				}
			}
			return null;
		}
		/// <summary>
		/// 视野,可选
		/// </summary>
		public Vision vision = null;
		/// <summary>
		/// 武器,可选
		/// </summary>
		public Gun mainWeapon = null;
		/// <summary>
		/// 导航网格运动
		/// </summary>
		public NavMeshAgent nav = null;
		/// <summary>
		/// 生命值上限
		/// </summary>
		[SerializeField]
		public float hpMax = 100;
		/// <summary>
		/// 毁尸延迟
		/// </summary>
		private const float corpseDestroyDelay = 2f;
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
		/// <summary>
		/// 是否活着
		/// </summary>
		/// <value><c>true</c> if is life; otherwise, <c>false</c>.</value>
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
		/// <summary>
		/// 检查是否活着的更新逻辑
		/// </summary>
		private void UpdateLifeState ()
		{
			if (hp <= float.Epsilon)
			{
				Die ();
			}
		}
		/// <summary>
		/// 击中事件
		/// </summary>
		/// <param name="bullet">Bullet.</param>
		public void OnHit(Bullet bullet)
		{
			hp -= bullet.damagePoint;
		}
		/// <summary>
		/// 是否被光照
		/// </summary>
		/// <value><c>true</c> if has light; otherwise, <c>false</c>.</value>
		public virtual bool hasLight
		{
			get{
				return HasBuff (BuffType.Light);
			}
		}
		/// <summary>
		/// 处死角色
		/// </summary>
		public void Die()
		{
			isLife = false;
			m_hp = 0;
			Destroy( gameObject, corpseDestroyDelay );
		}
		/// <summary>
		/// 更新逻辑
		/// </summary>
		protected virtual void Update()
		{
			UpdateHPText ();
		}
		/// <summary>
		/// 当前生命值
		/// </summary>
		[SerializeField]
		private float m_hp = 100;
		[SerializeField]
		private bool m_isLife = true;
	}
}