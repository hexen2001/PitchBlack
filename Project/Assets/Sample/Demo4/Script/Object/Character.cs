using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public enum Camp
	{
		Human,
		Monster,
	}
	public abstract class Character : BuffList
	{

		#region 生命相关

		public void AddValue(ItemType type, int value, ItemType maxType)
		{
			value += items.Get (type);
			if (maxType != ItemType.Unknown)
			{
				value = Mathf.Clamp (value, 0, items.Get (maxType));
			}
			items.Set (type, value);
		}



		[SerializeField]
		private bool m_isLife = true;


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

		public void Damage (int point)
		{
			hp -= point;
		}

		/// <summary>
		/// 造成伤害
		/// </summary>
		/// <param name="bullet"></param>
		public void Damage(Bullet bullet)
		{
			items.AddItem( ItemType.Hp, -bullet.damagePoint );
			Damage ( bullet.damagePoint);
		}



		/// <summary>
		/// 当前生命值
		/// </summary>
		/// <value>The hp.</value>
		public int hp
		{
			get
			{
				return items.Get( ItemType.Hp );
			}
			set
			{
				items.Set( ItemType.Hp, Mathf.Clamp( value, 0, hpMax ) );
			}
		}
		public int hpMax
		{
			get{
				return items.Get( ItemType.HpMax );
			}
			set{
				items.Set( ItemType.HpMax, value );
			}
		}


		/// <summary>
		/// 处死角色
		/// </summary>
		public void Die()
		{
			isLife = false;
			hp = 0;
			Destroy( gameObject, corpseDestroyDelay );
		}
		

		/// <summary>
		/// 检查是否活着的更新逻辑
		/// </summary>
		private void UpdateLifeState()
		{
			if( hp <= float.Epsilon )
			{
				Die();
			}
		}

		/// <summary>
		/// 恢复全部生命
		/// </summary>
		public void RestoreHP()
		{
			hp = hpMax;
		}

		
		/// <summary>
		/// 毁尸延迟
		/// </summary>
		private const float corpseDestroyDelay = 2f;


		#endregion
		#region 层与阵营关系

		public Camp camp = Camp.Human;


		public abstract Layer selfLayer
		{
			get;
		}


		public abstract Layer fireLayer
		{
			get;
		}


		#endregion
		#region 初始化

		public bool useGlobalSettings = true;
	
		protected void Init()
		{
			InitData();
			gameObject.layer = (int)selfLayer;
		}

		
		private void InitData()
		{
			if( useGlobalSettings )
			{
				OnData( Manager.main.settings );
			}
		}
		
		
		protected virtual void OnData(GameSettings settings)
		{
			items.AddItem( ItemType.Hp, 100 );
			items.AddItem( ItemType.HpMax, 100 );
		}

	
		#endregion
		#region GUI相关
		public Title title
		{
			get
			{
				if( null == m_title )
				{
					m_title = GetComponent<Title>();
				}
				return m_title;
			}
		}


		private Title m_title;


		private void UpdateGUI()
		{
			if( title != null )
			{
				title.text = ( (int)hp ).ToString() + "/" + ( (int)hpMax ).ToString();
			}
		}
		#endregion


		protected virtual void Awake()
		{
			Init();

			RestoreHP();
		}



		#region 战斗相关

		/// <summary>
		/// 开火方法
		/// </summary>
		public Bullet Fire()
		{
			if( mainWeapon != null && !mainWeapon.IsCooldownTime )
			{
				var bu = mainWeapon.Fire();
				if( bu != null )
				{
					bu.gameObject.layer = (int)fireLayer;
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

		#endregion



		#region 运动

		/// <summary>
		/// 导航网格运动
		/// </summary>
		public NavMeshAgent nav = null;

		#endregion


		/// <summary>
		/// 击中事件
		/// </summary>
		/// <param name="bullet">Bullet.</param> 
		public void OnHit(Bullet bullet)
		{
			Damage( bullet );
		}


		/// <summary>
		/// 是否被光照
		/// </summary>
		/// <value><c>true</c> if has light; otherwise, <c>false</c>.</value>
		public virtual bool hasLight
		{
			get
			{
				return items.Get( ItemType.Light ) > 0;
			}
		}


		/// <summary>
		/// 更新逻辑
		/// </summary>
		protected virtual void Update()
		{
			UpdateLifeState();
			UpdateGUI();
		}


	}
}