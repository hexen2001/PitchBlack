﻿using UnityEngine;
using System.Collections;


public class Character : TouchBase
{

	#region Motion
	public NavMeshAgent nav;
	[SerializeField]
	private Vector3 m_motionDir;
	private const float MinMotionDistance = 4f;
	public void SetMoveDir(Vector3 dir)
	{
		m_motionDir = dir;
		if( nav != null )
		{
			nav.SetDestination( moveDestPosition );
		}
	}
	private Vector3 moveDestPosition
	{
		get
		{
			return transform.position + m_motionDir * MinMotionDistance;
		}
	}
	public void StopMove()
	{
		nav.Stop();
		nav.ResetPath();
	}
	private void GizmosMotion()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine( transform.position, moveDestPosition );
	}
	#endregion



	#region Lights
	public bool lighting
	{
		get
		{
			return lightCount > 0;
		}
	}
	public int lightCount
	{
		get
		{
			return m_lightCount;
		}
		private set
		{
			m_lightCount = value;
		}
	}
	public virtual void AddLight(GameObject go)
	{
		lightCount++;
	}
	public virtual void RemoveLight(GameObject go)
	{
		lightCount--;
	}
	[SerializeField]
	private int m_lightCount = 0;
	#endregion




	#region Life
	public int hp = 100;
	public int hpMax = 100;
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
	private const float corpseHideDelay = 1f;
	public void Die()
	{
		if( !isLife )
		{
			return;
		}

		isLife = false;
		hp = 0;
		iTween.MoveAdd( gameObject, Vector3.down * 2f, 1f );
		Object.Destroy( gameObject, corpseHideDelay );
	}
	private void UpdateLife()
	{
	}
	public void Damage(int damagePoint)
	{
		if( isLife )
		{
			SetHP( hp - damagePoint );
			if( hp == 0 )
			{
				Die();
			}
		}
	}
	public void SetHP(int value)
	{
		hp = Mathf.Clamp( value, 0, hpMax );
	}
	#endregion


	#region Weapon


	public Gun gun
	{
		get
		{
			if( null == m_gun )
			{
				m_gun = GetComponent<Gun>();
			}
			return m_gun;
		}
	}
	[SerializeField]
	private Gun m_gun = null;

	public bool CheckFireRange(Vector3 pos)
	{
		if( gun != null )
		{
			return ( transform.position - pos ).magnitude <= gun.fireRange;
		}
		return false;
	}

	public void Fire()
	{
		if( !gun.isCooldown )
		{
			var bullet = gun.Fire();
			if( bullet != null )
			{
				bullet.attacker = this;
			}
		}
	}


	#endregion


	#region Be Hit

	public bool Hit(Bullet bullet)
	{
		if( isLife )
		{
			Damage( bullet.damagePoint );
			return true;
		}
		return false;
	}

	#endregion


	#region Event

	protected virtual void Start()
	{
	}

	protected virtual void OnGUI()
	{
		TitleUtil.labelStyle.normal.textColor = Color.blue;
		TitleUtil.position = transform.position;

		TitleUtil.offset = TitleUtil.Line1;
		TitleUtil.DrawLabel( hp + "/" + hpMax );

		TitleUtil.offset = TitleUtil.Line2;
		TitleUtil.DrawLabel( hp + "/" + hpMax );
	}

	protected virtual void OnDrawGizmos()
	{
		GizmosMotion();
		GizmosSelfToTarget();
	}

	protected virtual void Update()
	{
		UpdateLife();
	}

	#endregion

	#region AI
	public Character target
	{
		get
		{
			if( vision != null )
			{
				var first = vision.first;
				if (first != null)
				{
					return first.GetComponent<Character>();
				}
			}
			return null;
		}
	}
	private void GizmosSelfToTarget()
	{
		var obj = target;
		if( obj != null )
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine( transform.position, obj.transform.position );
		}
	}
	#endregion

	#region Vision
	public Vision vision = null;
	#endregion

}
